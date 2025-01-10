import React, { useState, useEffect } from "react";
import { Container, Row, Col, Card, Table, Spinner, Button } from "react-bootstrap";
import axios from "axios";
import { FaUsers, FaCheckCircle, FaTimesCircle, FaUserShield, FaBuilding, FaUniversity, FaGraduationCap } from "react-icons/fa"; // Added Graduation Cap icon
import { useNavigate } from "react-router-dom";
import { jwtDecode } from "jwt-decode";  
import "../../assets/styles/dashboard.css";
import RoleManagement from './roleManagement';



const AdminDashboard = () => {
  const [users, setUsers] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [currentPage, setCurrentPage] = useState(1);
  const [usersPerPage] = useState(10);
  const token = localStorage.getItem("jwtToken");
  const navigate = useNavigate();
  const [email, setEmail] = useState(null);

  useEffect(() => {
    if (token) {
      fetchUsers();
    } else {
      alert("Ju lutem, kyçuni përsëri.");
    }
  }, [token]);

  const fetchUsers = async () => {
    const storedEmail = localStorage.getItem("userEmail");
    if (storedEmail) {
      setEmail(storedEmail);
    }

    try {
      if (!token) {
        console.error("Token not found. Please log in again.");
        setError("Token not found. Please log in again.");
        return;
      }

      const response = await axios.get(
        "https://localhost:7071/api/User/all",
        { headers: { Authorization: `Bearer ${token}` } }
      );
  
      console.log('Fetched Users:', response.data);
      setUsers(response.data);
      setLoading(false);
    } catch (err) {
      console.error("Gabim gjatë marrjes së profileve të përdoruesve", err);
      setError("Dështoi të merreshin profilet e përdoruesve. Ju lutem, provoni përsëri.");
      setLoading(false);
    }
  };

  const handleRoleUpdated = () => {
    console.log('Roli u përditësua, duke marrë përdoruesit...');
    fetchUsers();
  };

  if (loading) {
    return (
      <div className="loading-spinner">
        <Spinner animation="border" variant="primary" />
      </div>
    );
  }

  const indexOfLastUser = currentPage * usersPerPage;
  const indexOfFirstUser = indexOfLastUser - usersPerPage;
  const currentUsers = users.slice(indexOfFirstUser, indexOfLastUser);

  return (
    <Container fluid>
      <Row className="my-4 text-center mb-6">
        <Col>
          <h1 className="text-center dashboard-title mt-4">Admin Dashboard</h1>
        </Col>
      </Row>

      <Row>
        <Col md={8} className="mx-auto">
          <Card className="text-center shadow-lg welcome-admin-card animated-card">
            <Card.Body className="p-4">
              <FaUserShield size={60} className="mb-3 text-white icon-background" />
              <Card.Title className="fs-4">Welcome, Admin!</Card.Title>
              <Card.Text className="welcome-admin-text">
                You can manage users, monitor activities, and ensure everything is running smoothly.
              </Card.Text>
              <p className="text-muted">Ensure a seamless experience for all users.</p>
            </Card.Body>
          </Card>
        </Col>

        <Col md={4} className="mx-auto">
          <Card className="text-center shadow-lg total-users-card animated-card">
            <Card.Body className="p-4">
              <FaUsers size={60} className="mb-3 text-white icon-background" />
              <Card.Title className="fs-4">Total Users</Card.Title>
              <Card.Text className="display-4">{users.length}</Card.Text>
              <p className="text-muted">Number of registered users</p>
            </Card.Body>
          </Card>
        </Col>
      </Row>

      <Row>
        <Col className="mb-4">
          <h2 className="my-4">User List</h2>
          <Table striped bordered hover responsive className="shadow-sm">
            <thead className="table-dark">
              <tr>
                <th>#</th>
                <th>Name</th>
                <th>Address</th>
                <th>Phone</th>
                <th>Academic Level</th>
                <th>Active</th>
                <th>Role</th>
              </tr>
            </thead>
            <tbody>
              {currentUsers.map((user, index) => (
                <tr key={user.id}>
                  <td>{index + 1 + indexOfFirstUser}</td>
                  <td>{`${user.emri} ${user.mbiemri}`}</td>
                  <td>{user.adresa || "N/A"}</td>
                  <td>{user.numriTelefonit || "Not any"}</td>
                  <td>{user.niveliAkademik || "N/A"}</td>
                  <td>
                    {user.isActive ? (
                      <FaCheckCircle className="text-success" />
                    ) : (
                      <FaTimesCircle className="text-danger" />
                    )}
                  </td>
                  <td>
                    <RoleManagement userId={user.id} token={token} onRoleUpdated={handleRoleUpdated} />
                  </td>
                </tr>
              ))}
            </tbody>
          </Table>
        </Col>
      </Row>

      <Row className="justify-content-center">
        <Col md={6} className="mb-4">
          <Card className="text-center shadow-lg manage-languages-card animated-card">
            <Card.Body className="p-4">
              <FaUsers size={60} className="mb-3 text-white icon-background" />
              <Card.Title className="fs-4 ac manage-languages-title">
                Manage Languages
              </Card.Title>
              <Button
                variant="primary"
                className="mt-2 btn-dark-blue"
                onClick={() => navigate("/manage-languages")}
              >
                Go to Manage Languages
              </Button>
            </Card.Body>
          </Card>
        </Col>

        <Col md={6} className="mb-4">
          <Card className="text-center shadow-lg manage-institucionet-card animated-card">
            <Card.Body className="p-4">
              <FaBuilding size={60} className="mb-3 text-white icon-background" />
              <Card.Title className="fs-4 manage-institucionet-title">
                Manage Institucionet
              </Card.Title>
              <Button
                variant="primary"
                className="mt-2 btn-dark-blue"
                onClick={() => navigate("/ManageInstitucioni")}
              >
                Go to Manage Institucionet
              </Button>
            </Card.Body>
          </Card>
        </Col>

        <Col md={6} className="mb-4">
          <Card className="text-center shadow-lg manage-departamentet-card animated-card">
            <Card.Body className="p-4">
              <FaUniversity size={60} className="mb-3 text-white icon-background" />
              <Card.Title className="fs-4 manage-departamentet-title">
                Manage Departamentet
              </Card.Title>
              <Button
                variant="primary"
                className="mt-2 btn-dark-blue"
                onClick={() => navigate("/ManageInstitucioni")}
              >
                Go to Manage Departamentet
              </Button>
            </Card.Body>
          </Card>
        </Col>

        <Col md={6} className="mb-4">
          <Card className="text-center shadow-lg manage-departamentet-card  animated-card">
            <Card.Body className="p-4">
              <FaGraduationCap size={60} className="mb-3 text-white icon-background" /> 
              <Card.Title className="fs-4  manage-departamentet-title">
                Manage Nivelet Akademike
              </Card.Title>
              <Button
                variant="primary"
                className="mt-2 btn-dark-blue"
                onClick={() => navigate("/manageniveliakademik")}
              >
                Go to Manage Nivelet Akademike
              </Button>
            </Card.Body>
          </Card>
        </Col>
      </Row>
    </Container>
  );
};

export default AdminDashboard;
