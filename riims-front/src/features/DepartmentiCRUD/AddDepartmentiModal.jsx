import React, { useState, useEffect } from 'react';
import "../../assets/styles/customModal.css";

function AddDepartamentModal({ show, onClose, onSave, token }) {
    const [emri, setEmri] = useState('');
    const [emriInstitucionit, setEmriInstitucionit] = useState('');
    const [isLoading, setIsLoading] = useState(false);
    const [error, setError] = useState('');

    useEffect(() => {
        if (!show) {
            setEmri('');
            setEmriInstitucionit('');
            setError('');
        }
    }, [show]);

    const handleSubmit = async (event) => {
        event.preventDefault();
        if (emri.trim() === '' || emriInstitucionit.trim() === '') {
            setError('Both fields are required.');
            return;
        }
        setIsLoading(true);
        setError('');
        try {
            const response = await fetch('https://localhost:7071/api/Departmenti', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${token}`
                },
                body: JSON.stringify({ emri, emriInstitucionit })
            });
            if (!response.ok) {
                throw new Error(`Failed to add department. Status: ${response.status}`);
            }
            const newDepartament = await response.json();
            onSave(newDepartament);
            onClose();
        } catch (error) {
            setError('Error adding the department. Please try again.');
        } finally {
            setIsLoading(false);
        }
    };

    return (
        <div className={`custom-modal ${show ? 'show' : ''}`}>
            <div className="custom-modal-content">
                <div className="custom-modal-header">
                    <h5>Shto Departmentin</h5>
                    <button className="close-button" onClick={() => {
                        onClose();
                        setEmri(''); 
                        setEmriInstitucionit('');
                        setError('');
                    }}>&times;</button>
                </div>
                <div className="custom-modal-body">
                    <form onSubmit={handleSubmit}>
                        <div className="form-group">
                            <label htmlFor="emri">Emri</label>
                            <input
                                id="emri"
                                type="text"
                                value={emri}
                                onChange={(e) => setEmri(e.target.value)}
                                placeholder="Enter department name"
                                className={`form-control ${error ? 'is-invalid' : ''}`}
                            />
                        </div>
                        <div className="form-group">
                            <label htmlFor="emriInstitucionit">Emri Institucionit</label>
                            <input
                                id="emriInstitucionit"
                                type="text"
                                value={emriInstitucionit}
                                onChange={(e) => setEmriInstitucionit(e.target.value)}
                                placeholder="Enter institution name"
                                className={`form-control ${error ? 'is-invalid' : ''}`}
                            />
                        </div>
                        {error && <div className="invalid-feedback">{error}</div>}
                        <div className="custom-modal-footer">
                            <button type="button" onClick={() => {
                                onClose();
                                setEmri('');
                                setEmriInstitucionit('');
                                setError('');
                            }} disabled={isLoading} className="btn btn-secondary">
                                Close
                            </button>
                            <button type="submit" disabled={isLoading} className="btn btn-primary">
                                {isLoading ? <span className="spinner-border spinner-border-sm" /> : 'Save'}
                            </button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    );
}

export default AddDepartamentModal;
