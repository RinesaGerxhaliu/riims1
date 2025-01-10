import React, { useState, useEffect } from "react";
//import { createBrowserRouter, RouterProvider, createRoutesFromElements, Route } from 'react-router-dom';
import { BrowserRouter as Router, Routes, Route, Navigate } from "react-router-dom";
import {jwtDecode} from "jwt-decode";
import Login from './features/auth/login';
import Register from './features/auth/register';
import Footer from "./components/layout/footer";
import LoggedInNavbar from "./components/layout/LoggedInNavbar";
import Home from './features/Home/homepage.jsx';
import PersonDetails from "./features/CVdetails/PersonDetails.jsx";
import Aftesite from "./features/AftesiaCRUD/AddAftesia.jsx";
import Publikimi from "./features/PublikimiCRUD/AddPublikimi.jsx";
import Specializimet from "./features/SpecializimiCRUD/AddSpecializimi.jsx";
import HonorsAndAwards from "./features/HonorsAndAwardsCRUD/AddHonorsAndAwards.jsx";
import Projekti from "./features/ProjektiCRUD/AddProjekti.jsx";
import Edukimi from "./features/EdukimiCRUD/AddEdukimi.jsx";
import Eksperienca from "./features/EksperiencaCRUD/AddEksperienca.jsx";
import Gjuhet from "./features/GjuhaCRUD/AddGjuha.jsx";
import Licensat from "./features/LicensaCRUD/AddLicensa.jsx";
import PunaVullnetare from "./features/PunaVullnetareCRUD/AddPunaVullnetare.jsx";
import MbikqyresITemave from "./features/MbikqyresITemaveCRUD/AddMbikqyresITemave.jsx";
import Dashboard from "./components/dashboard/dashboard.jsx";
import EditProfile from "./features/profile/EditProfile.jsx";
import EditAftesia from "./features/AftesiaCRUD/EditAftesia.jsx";
import EditEdukimi from "./features/EdukimiCRUD/EditEdukimi.jsx";
import EditEksperienca from "./features/EksperiencaCRUD/EditEksperienca.jsx";
import EditGjuhet from "./features/GjuhaCRUD/EditGjuhet.jsx";
import EditHonorsAndAwards from "./features/HonorsAndAwardsCRUD/EditHonorsAndAwards.jsx";
import EditLicensa from "./features/LicensaCRUD/EditLicensa.jsx";
import EditMbikqyres from "./features/MbikqyresITemaveCRUD/EditMbikqyres.jsx";
import EditProjekti from "./features/ProjektiCRUD/EditProjekti.jsx";
import EditPublikimi from "./features/PublikimiCRUD/EditPublikimi.jsx";
import EditPunaVullnetare from "./features/PunaVullnetareCRUD/EditPunaVullnetare.jsx";
import EditSpecializimi from "./features/SpecializimiCRUD/EditSpecializim.jsx";
import ManageLanguages from "./components/dashboard/GjuhetCRUD/ManageLanguages.jsx";
import ManageInstituconet from "./features/InstitucioniCRUD/ManageInstitucioni.jsx";
import ManageNiveletAkademike from "./features/NiveliAkademikCRUD/ManageNiveletAkaademike.jsx";

function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(false);
  const [isAdmin, setIsAdmin] = useState(false);

  const isTokenExpired = (token) => {
    if (!token) return true;
    try {
      const decodedToken = jwtDecode(token);
      const currentTime = Date.now() / 1000;
      return decodedToken.exp < currentTime;
    } catch (error) {
      console.error("Error decoding token:", error);
      return true;
    }
  };

  useEffect(() => {
    const token = localStorage.getItem("jwtToken");
    if (token && !isTokenExpired(token)) {
      try {
        const decodedToken = jwtDecode(token);
        setIsAdmin(decodedToken.role && decodedToken.role.toLowerCase() === "admin");
        setIsLoggedIn(true);
      } catch (error) {
        console.error("Error decoding token:", error);
        handleLogout();
      }
    } else {
      handleLogout();
    }
  }, []);

  const handleLogin = () => {
    setIsLoggedIn(true);
    localStorage.setItem("isLoggedIn", "true");
  };

  const handleLogout = () => {
    setIsLoggedIn(false);
    setIsAdmin(false);
    localStorage.removeItem("jwtToken");
    localStorage.removeItem("isLoggedIn");
  };

  return (
    <Router>
    <div className="App">

      <Routes>
        {isLoggedIn ? (
          <>
            <Route
              path="/"
              element={
                <>
                  <LoggedInNavbar handleLogout={handleLogout} />
                  <div className="container">
                    <Home />
                  </div>
                  <Footer />
                </>
              }
            />
              <Route
              path="/addAftesia"
              element={
                <>
                  <LoggedInNavbar handleLogout={handleLogout} />
                  <div className="container mt-4">
                    <Aftesite />
                  </div>
                  <Footer />
                </>
              }
            />
               <Route
              path="/Home"
              element={
                <>
                  <LoggedInNavbar handleLogout={handleLogout} />
                  <div className="container mt-4">
                    <Home />
                  </div>
                  <Footer />
                </>
              }
            />
            <Route
              path="/PersonDetails"
              element={
                <>
                  <LoggedInNavbar handleLogout={handleLogout} />
                  <div className="container mt-4">
                    <PersonDetails />
                  </div>
                  <Footer />
                </>
              }
            />
             <Route
              path="/publikimi"
              element={
                <>
                  <LoggedInNavbar handleLogout={handleLogout} />
                  <div className="container mt-4">
                    <Publikimi />
                  </div>
                  <Footer />
                </>
              }
            />
              <Route
              path="/specializimet"
              element={
                <>
                  <LoggedInNavbar handleLogout={handleLogout} />
                  <div className="container mt-4">
                    <Specializimet />
                  </div>
                  <Footer />
                </>
              }
            />
            <Route
              path="/honorsandawards"
              element={
                <>
                  <LoggedInNavbar handleLogout={handleLogout} />
                  <div className="container mt-4">
                    <HonorsAndAwards />
                  </div>
                  <Footer />
                </>
              }
            />
            <Route
              path="/projekti"
              element={
                <>
                  <LoggedInNavbar handleLogout={handleLogout} />
                  <div className="container mt-4">
                    <Projekti />
                  </div>
                  <Footer />
                </>
              }
            />
            <Route
              path="/edukimi"
              element={
                <>
                  <LoggedInNavbar handleLogout={handleLogout} />
                  <div className="container mt-4">
                    <Edukimi />
                  </div>
                  <Footer />
                </>
              }
            />
            <Route
              path="/eksperienca"
              element={
                <>
                  <LoggedInNavbar handleLogout={handleLogout} />
                  <div className="container mt-4">
                    <Eksperienca />
                  </div>
                  <Footer />
                </>
              }
            />
            <Route
              path="/gjuhet"
              element={
                <>
                  <LoggedInNavbar handleLogout={handleLogout} />
                  <div className="container mt-4">
                    <Gjuhet />
                  </div>
                  <Footer />
                </>
              }
            />
            <Route
              path="/licensat"
              element={
                <>
                  <LoggedInNavbar handleLogout={handleLogout} />
                  <div className="container mt-4">
                    <Licensat />
                  </div>
                  <Footer />
                </>
              }
            />
            <Route
              path="/punavullnetare"
              element={
                <>
                  <LoggedInNavbar handleLogout={handleLogout} />
                  <div className="container mt-4">
                    <PunaVullnetare />
                  </div>
                  <Footer />
                </>
              }
            />
            <Route
              path="/mbikqyresitemave"
              element={
                <>
                  <LoggedInNavbar handleLogout={handleLogout} />
                  <div className="container mt-4">
                    <MbikqyresITemave />
                  </div>
                  <Footer />
                </>
              }
            />
             <Route
              path="/dashboard"
              element={
                <>
                  <LoggedInNavbar handleLogout={handleLogout} />
                  <div className="container mt-4">
                    <Dashboard />
                  </div>
                  <Footer />
                </>
              }
            />
            <Route
              path="/edit-profile"
              element={
                <>
                  <LoggedInNavbar handleLogout={handleLogout} />
                  <div className="container mt-4">
                    <EditProfile />
                  </div>
                  <Footer />
                </>
              }
            />
              <Route
              path="/manage-languages"
              element={
                <>
                  <LoggedInNavbar handleLogout={handleLogout} />
                  <div className="container mt-4">
                    <ManageLanguages />
                  </div>
                  <Footer />
                </>
              }
            />
            <Route
              path="/EditAftesia/:id"
              element={
                <>
                  <LoggedInNavbar handleLogout={handleLogout} />
                  <div className="container mt-4">
                    <EditAftesia />
                  </div>
                  <Footer />
                </>
              }
            />
            <Route
              path="/EditEdukimi/:id"
              element={
                <>
                  <LoggedInNavbar handleLogout={handleLogout} />
                  <div className="container mt-4">
                    <EditEdukimi />
                  </div>
                  <Footer />
                </>
              }
            />
            <Route
              path="/EditEksperienca/:id"
              element={
                <>
                  <LoggedInNavbar handleLogout={handleLogout} />
                  <div className="container mt-4">
                    <EditEksperienca />
                  </div>
                  <Footer />
                </>
              }
            />
            <Route
              path="/EditGjuhet/:id"
              element={
                <>
                  <LoggedInNavbar handleLogout={handleLogout} />
                  <div className="container mt-4">
                    <EditGjuhet />
                  </div>
                  <Footer />
                </>
              }
            />
            <Route
              path="/EditHonorsAndAwards/:id"
              element={
                <>
                  <LoggedInNavbar handleLogout={handleLogout} />
                  <div className="container mt-4">
                    <EditHonorsAndAwards />
                  </div>
                  <Footer />
                </>
              }
            />
            <Route
              path="/EditLicensa/:id"
              element={
                <>
                  <LoggedInNavbar handleLogout={handleLogout} />
                  <div className="container mt-4">
                    <EditLicensa />
                  </div>
                  <Footer />
                </>
              }
            />
            <Route
              path="/EditMbikqyres/:id"
              element={
                <>
                  <LoggedInNavbar handleLogout={handleLogout} />
                  <div className="container mt-4">
                    <EditMbikqyres />
                  </div>
                  <Footer />
                </>
              }
            />
            <Route
              path="/EditProjekti/:id"
              element={
                <>
                  <LoggedInNavbar handleLogout={handleLogout} />
                  <div className="container mt-4">
                    <EditProjekti />
                  </div>
                  <Footer />
                </>
              }
            />
            <Route
              path="/EditPublikimi/:id"
              element={
                <>
                  <LoggedInNavbar handleLogout={handleLogout} />
                  <div className="container mt-4">
                    <EditPublikimi />
                  </div>
                  <Footer />
                </>
              }
            />
            <Route
              path="/EditPunaVullnetare/:id"
              element={
                <>
                  <LoggedInNavbar handleLogout={handleLogout} />
                  <div className="container mt-4">
                    <EditPunaVullnetare />
                  </div>
                  <Footer />
                </>
              }
            />
            <Route
              path="/EditSpecializimi/:id"
              element={
                <>
                  <LoggedInNavbar handleLogout={handleLogout} />
                  <div className="container mt-4">
                    <EditSpecializimi />
                  </div>
                  <Footer />
                </>
              }
            />
              <Route
              path="/ManageInstitucioni"
              element={
                <>
                  <LoggedInNavbar handleLogout={handleLogout} />
                  <div className="container mt-4">
                    <ManageInstituconet />
                  </div>
                  <Footer />
                </>
              }
            />
             <Route
              path="/manageniveliakademik"
              element={
                <>
                  <LoggedInNavbar handleLogout={handleLogout} />
                  <div className="container mt-4">
                    <ManageNiveletAkademike />
                  </div>
                  <Footer />
                </>
              }
            />
            {/* 

            <Route path="/thecv" element={
              <>
                <LoggedInNavbar handleLogout={handleLogout} />
                <div className="container mt-4">
                  <TheCV />
                </div>
                <Footer />
              </>
            } />
            />
           
            /> */}
            <Route path="*" element={<Navigate to="/" />} />
          </>
        ) : (
          <>

            <Route path="/login" element={<Login onLogin={handleLogin} />} />
            <Route path="/register" element={<Register />} />
            <Route path="*" element={<Navigate to="/login" />} />
          </>
        )}
      </Routes>
    </div>
  </Router>
  );
}

export default App;
