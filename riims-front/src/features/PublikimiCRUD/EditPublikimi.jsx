import React, { useState, useEffect } from 'react';
import axios from 'axios';
import Select from 'react-select';
import EditSidebar from '../../components/layout/EditSidebar.jsx';
import { useParams, useNavigate } from 'react-router-dom';

const publikimiTypes = [
    { value: 'Article', label: 'Article' },
    { value: 'Book', label: 'Book' },
    { value: 'Conference Paper', label: 'Conference Paper' },
    { value: 'Journal Paper', label: 'Journal Paper' },
];

const jwtTokenKey = 'jwtToken';  // Use constant for token key

function EditPublikimi() {
    const { id } = useParams();
    const navigate = useNavigate();
    const initialFormData = {
        titulli: '',
        llojiPublikimit: null,
        linkuPublikimit: '',
        autoriKryesor: false,
        dataPublikimi: '',
        emriDepartamentit: null,
    };

    const [formData, setFormData] = useState(initialFormData);
    const [departamentet, setDepartamentet] = useState([]);
    const [errorMessage, setErrorMessage] = useState('');
    const [successMessage, setSuccessMessage] = useState('');
    const [loading, setLoading] = useState(false); // Add loading state

    useEffect(() => {
        const fetchDepartamentet = async () => {
            try {
                const token = localStorage.getItem(jwtTokenKey);

                if (!token) {
                    throw new Error('Token not found');
                }

                const response = await axios.get('https://localhost:7071/api/Departmenti', {
                    headers: {
                        'Authorization': `Bearer ${token}`,
                    },
                });
                
                const options = response.data.map(departamenti => ({
                    value: departamenti.id,
                    label: departamenti.emri
                }));
                setDepartamentet(options);
            } catch (error) {
                console.error('Error gjatë marrjes së departamenteve:', error.response ? error.response.data : error.message);
                setErrorMessage('Dështoi marrja e departamenteve.');
            }
        };

        const fetchPublikimi = async () => {
            try {
                const token = localStorage.getItem(jwtTokenKey);

                if (!token) {
                    throw new Error('Token not found');
                }

                const response = await axios.get(`https://localhost:7071/api/Publikimi/${id}`, {
                    headers: {
                        'Authorization': `Bearer ${token}`,
                    },
                });
                const formatDate = (isoDate) => {
                    if (!isoDate) return "";
                    const date = new Date(isoDate);
                    return date.toISOString().split("T")[0]; // YYYY-MM-DD
                  };

                setFormData({
                    titulli: response.data.titulli,
                    llojiPublikimit: response.data.llojiPublikimit,
                    linkuPublikimit: response.data.linkuPublikimit || '',
                    autoriKryesor: response.data.autoriKryesor,
                    dataPublikimi:  formatDate(response.data.dataPublikimi) || "",
                    emriDepartamentit: response.data.emriDepartamentit || null,
                });
            } catch (error) {
                console.error('Error gjatë marrjes së publikimit:', error.response ? error.response.data : error.message);
                setErrorMessage('Dështoi marrja e publikimit.');
            }
        };

        fetchDepartamentet();
        fetchPublikimi();
    }, [id]);

    const handleChange = (e) => {
        setFormData({
            ...formData,
            [e.target.name]: e.target.value
        });
    };

    const handleSelectChange = (selectedOption) => {
        setFormData({
            ...formData,
            llojiPublikimit: selectedOption ? selectedOption.value : null
        });
    };

    const handleDepartmentChange = (selectedOption) => {
        setFormData({
            ...formData,
            emriDepartamentit: selectedOption ? selectedOption.label : ''
        });
    };

    const handleCheckboxChange = (e) => {
        setFormData({
            ...formData,
            autoriKryesor: e.target.checked
        });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        setErrorMessage('');
        setSuccessMessage('');
        setLoading(true);  // Set loading true on submit

        const token = localStorage.getItem(jwtTokenKey);

        if (!token) {
            setErrorMessage('Ju lutem logohuni përsëri.');
            setLoading(false);
            return;
        }

        try {
            const data = {
                Titulli: formData.titulli,
                LlojiPublikimit: formData.llojiPublikimit,
                LinkuPublikimit: formData.linkuPublikimit || null,
                AutoriKryesor: formData.autoriKryesor,
                DataPublikimi: formData.dataPublikimi ,
                EmriDepartamentit: formData.emriDepartamentit
            };

            const response = await axios.put(
                `https://localhost:7071/api/Publikimi/${id}`,
                data,
                {
                    headers: {
                        'Authorization': `Bearer ${token}`,
                        'Content-Type': 'application/json'
                    }
                }
            );

            if (response.status === 200) {
                setSuccessMessage('Publikimi u përditësua me sukses!');
            } else {
                setErrorMessage('Diçka shkoi keq. Ju lutem provoni përsëri.');
            }

        } catch (error) {
            console.error('Error during publication update:', error);
            setErrorMessage(error.response?.data?.message || 'Ju lutem provoni përsëri.');
        }

        setLoading(false); 
    };

    const handleReset = () => {
        setFormData(initialFormData);
    };

    useEffect(() => {
        if (errorMessage || successMessage) {
            const timer = setTimeout(() => {
                setErrorMessage('');
                setSuccessMessage('');
            }, 6000);
            return () => clearTimeout(timer);
        }
    }, [errorMessage, successMessage]);

    return (
        <div className="container-fluid h-100 bg-light">
            <div className="row h-100">
                <div className="col-md-2 p-0">
                    <EditSidebar />
                </div>

                <div className="col-md-10 d-flex justify-content-center align-items-start py-5">
                    <div className="col-12 col-md-10 col-lg-8 col-xl-6">
                        <h4 className="text-center text-muted fst-italic mb-4">Editoni publikimin tuaj</h4>

                        {errorMessage && (
                            <div className="alert alert-danger text-center mb-3" role="alert">
                                {errorMessage}
                            </div>
                        )}

                        {successMessage && (
                            <div className="alert alert-success text-center mb-3" role="alert">
                                {successMessage}
                            </div>
                        )}

                        <form onSubmit={handleSubmit} className="p-3 border rounded shadow bg-white" style={{ marginTop: '1rem' }}>
                            <div className="row">
                                <div className="col-md-6 mb-4">
                                    <div className="form-group">
                                        <label htmlFor="titulli" className="form-label fw-bold">Titulli</label>
                                        <input
                                            type="text"
                                            className="form-control"
                                            id="titulli"
                                            name="titulli"
                                            value={formData.titulli}
                                            onChange={handleChange}
                                            placeholder="Shkruani titullin e publikimit"
                                        />
                                    </div>
                                </div>

                                <div className="col-md-6 mb-4">
                                    <div className="form-group">
                                        <label id="llojiPublikimit-label" className="form-label fw-bold">Lloji i publikimit</label>
                                        <Select
                                            aria-labelledby="llojiPublikimit-label"
                                            options={publikimiTypes}
                                            value={publikimiTypes.find(option => option.value === formData.llojiPublikimit) || null}
                                            onChange={handleSelectChange}
                                            placeholder="Zgjedhni llojin"
                                        />
                                    </div>
                                </div>

                                <div className="col-md-6 mb-4">
                                    <div className="form-group">
                                        <label htmlFor="linkuPublikimit" className="form-label fw-bold">Linku i publikimit</label>
                                        <input
                                            type="text"
                                            className="form-control"
                                            id="linkuPublikimit"
                                            name="linkuPublikimit"
                                            value={formData.linkuPublikimit}
                                            onChange={handleChange}
                                            placeholder="Shkruani linkun e publikimit"
                                        />
                                    </div>
                                </div>

                                <div className="col-md-6 mb-4 d-flex align-items-center">
                                    <input
                                        type="checkbox"
                                        className="form-check-input"
                                        id="autoriKryesor"
                                        name="autoriKryesor"
                                        checked={formData.autoriKryesor}
                                        onChange={handleCheckboxChange}
                                        style={{ marginTop: '1.25rem' }}  // Add margin to push it lower
                                        />
                                        <label htmlFor="autoriKryesor" className="ms-2">Autori kryesor</label>
                                    </div>
    
                                    <div className="col-md-6 mb-4">
                                        <div className="form-group">
                                            <label htmlFor="dataPublikimi" className="form-label fw-bold">Data e publikimit</label>
                                            <input
                                                type="date"
                                                className="form-control"
                                                id="dataPublikimi"
                                                name="dataPublikimi"
                                                value={formData.dataPublikimi}
                                                onChange={handleChange}
                                            />
                                        </div>
                                    </div>
    
                                    <div className="col-md-6 mb-4">
                                        <div className="form-group">
                                            <label id="emriDepartamentit-label" className="form-label fw-bold">Departamenti</label>
                                            <Select
                                                aria-labelledby="emriDepartamentit-label"
                                                options={departamentet}
                                                value={departamentet.find(option => option.label === formData.emriDepartamentit) || null}
                                                onChange={handleDepartmentChange}
                                                placeholder="Zgjedhni departamentin"
                                            />
                                        </div>
                                    </div>
                                </div>
                                <div className="col-md-12 d-flex justify-content-between mb-2">
                                    <button type="button" className="btn btn-secondary" onClick={handleReset} style={{ width: 'calc(50% - 0.7rem)' }}>Anulo</button>
                                    <button type="submit" className="btn btn-primary" style={{ width: 'calc(50% - 0.7rem)' }}>Ruaj</button>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
    
    export default EditPublikimi;
    