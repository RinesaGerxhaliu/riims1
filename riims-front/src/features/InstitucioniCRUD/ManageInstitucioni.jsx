import React, { useState, useEffect, useCallback } from "react";
import { Container, Row, Col, Table, Button } from "react-bootstrap";
import axios from "axios";
import AddInstitucioniModal from "./AddInstitucioniModal"; 
import EditInstitucioniModal from "./EditInstitucioniModal"; 
//import AddDepartamentiModal from "../DepartmentiCRUD/EditDepartmentiModal"; 
import AddDepartamentiModal from "../DepartmentiCRUD/AddDepartmentiModal"; 
import "../../assets/styles/ManageInstitucioni.css";

const ManageInstitucioni = () => {
  const [institutions, setInstitutions] = useState([]);
  const [departments, setDepartments] = useState([]);
  const [showAddInstitucioniModal, setShowAddInstitucioniModal] = useState(false);
  const [showEditInstitucioniModal, setShowEditInstitucioniModal] = useState(false);
  const [showAddDepartamentiModal, setShowAddDepartamentiModal] = useState(false);
  const [showEditDepartamentiModal, setShowEditDepartamentiModal] = useState(false);
  const [currentInstitution, setCurrentInstitution] = useState(null);
  const [currentDepartment, setCurrentDepartment] = useState(null);
  const token = localStorage.getItem("jwtToken");

  const fetchData = useCallback(async () => {
    try {
      const [institutionsResponse, departmentsResponse] = await Promise.all([
        axios.get("https://localhost:7071/api/Institucioni", {
          headers: { Authorization: `Bearer ${token}` },
        }),
        axios.get("https://localhost:7071/api/Departmenti", {
          headers: { Authorization: `Bearer ${token}` },
        }),
      ]);

      setInstitutions(institutionsResponse.data);
      setDepartments(departmentsResponse.data);
    } catch (error) {
      console.error("Error fetching data:", error);
    }
  }, [token]);

  useEffect(() => {
    fetchData();
  }, [fetchData]);

  const handleAddInstitucioni = (newInstitution) => {
    setInstitutions((prevInstitutions) => [newInstitution, ...prevInstitutions]);
  };

  const handleEditInstitucioni = (updatedInstitution) => {
    setInstitutions((prevInstitutions) =>
      prevInstitutions.map((institution) =>
        institution.id === updatedInstitution.id ? updatedInstitution : institution
      )
    );
  };

  const handleEditInstitutionClick = (institution) => {
    setCurrentInstitution(institution);
    setShowEditInstitucioniModal(true);
  };

  const handleAddDepartamenti = (newDepartment) => {
    setDepartments((prevDepartments) => [newDepartment, ...prevDepartments]);
  };

  const handleEditDepartamenti = (updatedDepartment) => {
    setDepartments((prevDepartments) =>
      prevDepartments.map((department) =>
        department.id === updatedDepartment.id ? updatedDepartment : department
      )
    );
  };

  const handleEditDepartmentClick = (department) => {
    setCurrentDepartment(department);
    setShowEditDepartamentiModal(true);
  };

  return (
    <Container fluid className="mt-4">
      <Row>
        <Col md={6}>
          <div className="d-flex justify-content-between align-items-center mb-3">
            <h4>Institucionet</h4>
            <Button
              variant="outline-success"
              onClick={() => setShowAddInstitucioniModal(true)}
            >
              <i className="bi bi-plus-lg"></i> Shto
            </Button>
          </div>
          <Table striped bordered hover className="custom-table">
            <thead>
              <tr>
                <th className="institution-column">Institucioni</th>
                <th className="table-actions">Edit</th>
              </tr>
            </thead>
            <tbody>
              {institutions.length > 0 ? (
                institutions.map((institution) => (
                  <tr key={institution.id}>
                    <td>{institution.emri}</td>
                    <td>
                      <Button
                        variant="primary"
                        className="btn btn-custom btn-sm custom-primary-btn"
                        onClick={() => handleEditInstitutionClick(institution)}
                      >
                        <i className="bi bi-pencil-fill me-2"></i> Edit
                      </Button>
                    </td>
                  </tr>
                ))
              ) : (
                <tr>
                  <td colSpan="2" className="text-center">No institutions found</td>
                </tr>
              )}
            </tbody>
          </Table>
        </Col>

        <Col md={6}>
          <div className="d-flex justify-content-between align-items-center mb-3">
            <h4>Departamentet</h4>
            <Button
              variant="outline-success"
              onClick={() => setShowAddDepartamentiModal(true)}
            >
              <i className="bi bi-plus-lg"></i> Shto
            </Button>
          </div>
          <Table striped bordered hover className="custom-table">
            <thead>
              <tr>
                <th className="department-column">Departamenti</th>
                {/* <th className="table-actions">Edit</th> */}
              </tr>
            </thead>
            <tbody>
              {departments.length > 0 ? (
                departments.map((department) => (
                  <tr key={department.id}>
                    <td>{department.emri}</td>
                    {/* <td>
                      <Button
                        variant="primary"
                        className="btn btn-custom btn-sm custom-primary-btn"
                        onClick={() => handleEditDepartmentClick(department)}
                      >
                        <i className="bi bi-pencil-fill me-2"></i> Edit
                      </Button>
                    </td> */}
                  </tr>
                ))
              ) : (
                <tr>
                  <td colSpan="2" className="text-center">No departments found</td>
                </tr>
              )}
            </tbody>
          </Table>
        </Col>
      </Row>

      {/* Modals for Institutions */}
      <AddInstitucioniModal
        show={showAddInstitucioniModal}
        onClose={() => setShowAddInstitucioniModal(false)}
        onSave={handleAddInstitucioni}
        token={token}
      />

      {currentInstitution && (
        <EditInstitucioniModal
          show={showEditInstitucioniModal}
          onClose={() => setShowEditInstitucioniModal(false)}
          onSave={handleEditInstitucioni}
          token={token}
          institution={currentInstitution}
        />
      )}

      {/* Modals for Departments */}
      <AddDepartamentiModal
        show={showAddDepartamentiModal}
        onClose={() => setShowAddDepartamentiModal(false)}
        onSave={handleAddDepartamenti}
        token={token}
      />

     
    </Container>
  );
};

export default ManageInstitucioni;
