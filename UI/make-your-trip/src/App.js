import logo from './logo.svg';
import './App.css';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Box } from '@mui/material';
import {Typography, Link } from '@mui/material';
import NotFound  from './Components/NotFound';
import { useContext, useEffect, useState } from 'react';
import  {ApiContext}  from './Components/ApiContextProvider';
import Login from './Components/Login';
import Contact from './Components/Contact';
import Home from './Components/Home';
import Signup from './Components/Signup';
import Admin from './Components/Admin';
import Package from './Components/Package';
import Gallery from './Components/Gallery';
import Agent from './Components/Agent';
import Navbar from './Components/Navbar';
import Footer from './Components/Footer';
import Landing from './Components/Landing';
import Preloader from './Components/Preloader';

function App() {
  const { userRole, userToken, userId, userName } = useContext(ApiContext);
  const [isLoading, setIsLoading] = useState(true);

  useEffect(() => {
    setTimeout(() => {
      setIsLoading(false);
    }, 3000);
  })
  return (
    <>
    {isLoading ? (
      <Preloader />
    ) : (
    <div >

    <link href="https://fonts.googleapis.com/css2?family=Poppins&display=swap" rel="stylesheet"></link>


    <Box>
      <Navbar/>
      <Routes>
        <Route path="/login" element={(userRole !== 'Admin' && userRole !=='Agent' && userRole !=='User') ?<Login />: <NotFound/> } />
        <Route path="/signup" element={(userRole !== 'Admin' && userRole !=='Agent' && userRole !=='User') ?<Signup />: <NotFound/> } />
        <Route path="/contactus" element={< Contact />}/>
        <Route path="/" element={<Landing />} />
        <Route path="/home" element={(userRole =='User') ?<Home />: <NotFound/> } />

        <Route path="/postgallery" element={<Gallery />} />
        <Route path="/admin" element={userRole === 'Admin' ? <Admin /> : <NotFound />}/>
        <Route path="/agent" element={userRole === 'Agent' ? <Agent /> : <NotFound />}/> 
        <Route path="/user" element={(userRole === 'Admin' || userRole === 'Agent' || userRole === 'User') ? <Home /> : <NotFound />}/> 
        <Route path="/package-details" element={(userRole === 'Admin' || userRole === 'Agent' || userRole === 'User') ? <Package /> : <NotFound />}/> 
        <Route path="/*" element={<NotFound />} />
      </Routes>
      <Footer/>
    </Box>
  </div>
    )}
    </>
  );
}

export default App;
