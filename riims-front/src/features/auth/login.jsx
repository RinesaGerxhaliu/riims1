import React, { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { login } from '../../features/auth/authService';
import RiimsLogo from '../../assets/images/riims-logo.png';
import '../../assets/styles/login.css';

const Login = ({ onLogin }) => {
    const [formData, setFormData] = useState({ Username: '', Password: '' });
    const [error, setError] = useState('');
    const navigate = useNavigate();

    const handleChange = (e) => {
        setFormData({ ...formData, [e.target.id]: e.target.value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        setError('');
        try {
            await login(formData);
            onLogin();
            navigate("/home");
        } catch (error) {
            setError("Login failed. Please check your credentials.");
        }
    };

    return (
        <div className="container-fluid">
            <div className="row vh-100">
            <div className="col-lg-6 d-flex align-items-center justify-content-center bg-light p-0">
            <div className="register-form-container p-5 w-100">
                        <div className="text-center mb-4">
                            <img src={RiimsLogo} style={{ width: '220px' }} alt="Riims Logo" />
                        </div>
                        <form onSubmit={handleSubmit}>
                            <div className="mb-3">
                                <label htmlFor="username" className="form-label">Email address</label>
                                <input
                                    type="email"
                                    className="form-control"
                                    id="Username"
                                    placeholder="Enter email"
                                    value={formData.Username}
                                    onChange={handleChange}
                                    required
                                />
                            </div>
                            <div className="mb-3">
                                <label htmlFor="Password" className="form-label">Password</label>
                                <input
                                    type="Password"
                                    className="form-control"
                                    id="Password"
                                    placeholder="Enter password"
                                    value={formData.Password}
                                    onChange={handleChange}
                                    required
                                />
                            </div>
                            {error && <p className="text-danger">{error}</p>}
                            <div className="text-center pt-2 mb-3">
                                <button className="btn btn-dark-blue w-50" type="submit">Sign in</button>
                            </div>
                            <div className="d-flex flex-row align-items-center justify-content-center">
                                <p className="mb-0">Don't have an account?</p>
                                <Link to="/register" className="btn btn-outline-danger mx-2">Sign Up</Link>
                            </div>
                        </form>
                    </div>
                </div>

                <div className="col-lg-6 d-flex align-items-center bg-dark-blue text-white p-0">
                <div className="text-white p-5">
                        <h4>Research Innovation and Information Management System</h4>
                        <p>
                            Welcome to RIIMS, the platform where research and innovation come together.
                            Manage information, collaborate with colleagues, and streamline your research process.
                        </p>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default Login;
