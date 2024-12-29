// import React, { createContext, useContext, useState, useEffect } from "react";
// import jwtDecode from "jwt-decode";

// const AuthContext = createContext();

// export const AuthProvider = ({ children }) => {
//   const [isLoggedIn, setIsLoggedIn] = useState(false);
//   const [isAdmin, setIsAdmin] = useState(false);

//   const isTokenExpired = (token) => {
//     if (!token) return true;
//     try {
//       const decodedToken = jwtDecode(token);
//       const currentTime = Date.now() / 1000;
//       return decodedToken.exp < currentTime;
//     } catch (error) {
//       console.error("Error decoding token:", error);
//       return true;
//     }
//   };

//   useEffect(() => {
//     const token = localStorage.getItem("jwtToken");
//     if (token && !isTokenExpired(token)) {
//       try {
//         const decodedToken = jwtDecode(token);
//         setIsAdmin(
//           decodedToken.role && decodedToken.role.toLowerCase() === "admin"
//         );
//         setIsLoggedIn(true);
//       } catch (error) {
//         console.error("Error decoding token:", error);
//         handleLogout();
//       }
//     } else {
//       handleLogout();
//     }
//   }, []);

//   const handleLogin = (token) => {
//     localStorage.setItem("jwtToken", token);
//     setIsLoggedIn(true);
//     const decodedToken = jwtDecode(token);
//     setIsAdmin(
//       decodedToken.role && decodedToken.role.toLowerCase() === "admin"
//     );
//   };

//   const handleLogout = () => {
//     setIsLoggedIn(false);
//     setIsAdmin(false);
//     localStorage.removeItem("jwtToken");
//     window.location.href = "/login";
//   };

//   return (
//     <AuthContext.Provider value={{ isLoggedIn, isAdmin, handleLogin, handleLogout }}>
//       {children}
//     </AuthContext.Provider>
//   );
// };

// export const useAuth = () => useContext(AuthContext);
