import React, { useContext, useState } from 'react';
import { Box, AppBar, Toolbar, Button, useMediaQuery } from '@mui/material';
import { Link } from 'react-router-dom';
import { ApiContext } from './ApiContextProvider';
const Navbar = () => {
    const isWideScreen = useMediaQuery('(min-width: 510px)');

  // Simulate user roles (you can get this from your authentication system)
  const { userRole, userToken, userName, setUserName, setUserRole, setUserToken, userId, setUserId } = useContext(ApiContext);
  const handleLogout = () => {
    // Perform logout actions here, e.g., clear local storage or session
    setUserRole('');
    setUserName('');
    setUserToken('');
    setUserId('');

    sessionStorage.removeItem('userRole');
    sessionStorage.removeItem('userToken');
    sessionStorage.removeItem('userName');
    sessionStorage.removeItem('userId');

  };
  return (
<AppBar position="" sx={{ backgroundColor: '', width: '100%' }}>
      <Toolbar>
        <Box
          display="flex"
          justifyContent="space-between"
          alignItems="center"
          width="100%"
          sx={{
            alignItems: "center",
            position: 'relative', // Add relative positioning for the parent Box
            maxWidth: '1600px', // Set the maximum width for the content
            margin: '0 auto', // Center the content horizontally
          }}
        >
          <Box
            display="flex"
            alignItems="center"
            sx={{
              flexGrow: 1, // Let this Box grow to fill the available space
            }}
          >
            {/* Your logo or brand */}
            {/* <img src={logo} alt="Logo" style={{ height: '30px', marginRight: '5px' }} /> */}
            {isWideScreen && <h2>Make Your<span>Trip</span></h2>}
          </Box>
          <Box>
            <Button color="inherit" component={Link} to="/">Landing</Button>
            <Button color="inherit" component={Link} to="/postgallery">Gallery</Button>
            {userRole === 'Admin' && <Button color="inherit" component={Link} to="/Admin">Admin</Button>}
            {userRole === 'Agent' && <Button color="inherit" component={Link} to="/Agent">Agent</Button>}
            {userRole === 'User' && <Button color="inherit" component={Link} to="/home">Home</Button>}
            {(userRole === 'Admin' || userRole === 'Agent' || userRole === 'User') ? (
              <>
              {console.log(userRole)}
                <Button color="inherit" onClick={handleLogout}>Logout</Button>
              </>
            ) : (
              <>
                            {console.log(userRole)}
                <Button color="inherit" component={Link} to="/login">Login</Button>
                <Button color="inherit" component={Link} to="/signup">Sign Up</Button>
              </>
            )}
            <Button color="inherit" component={Link} to="/contactus">Contact</Button>
          </Box>
        </Box>
      </Toolbar>
    </AppBar>  )
}

export default Navbar