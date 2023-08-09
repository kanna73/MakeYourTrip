import React from 'react';
import { Container, Grid, Typography, Link } from '@mui/material';

const Footer = () => {
  const footerStyle = {
    backgroundColor: '#1976d2',
    color: '#fff',
    padding: '20px 0',
  };

  const linkStyle = {
    color: '#fff',
    textDecoration: 'none',
    '&:hover': {
      textDecoration: 'underline',
    },
  };

  return (
    <footer style={footerStyle}>
      <Container maxWidth="lg">
        <Grid container spacing={3}>
          <Grid item xs={12} sm={6} md={4}>
            <Typography variant="h6" gutterBottom>
              About Us
            </Typography>
            <Typography variant="body2">
            Our mission is to inspire and empower you to explore the beauty of this planet, fostering a deeper appreciation for our global community. We aim to make travel accessible, sustainable, and enriching, ensuring that every journey you embark upon with us leaves a positive impact on both the environment and the local communities you visit.
            </Typography>
          </Grid>
          <Grid item xs={12} sm={6} md={4}>
            <Typography variant="h6" gutterBottom>
              Contact Us
            </Typography>
            <Typography variant="body2">
              Email: maketourtrip@gmail.com
            </Typography>
            <Typography variant="body2">
              Phone: +123 456 7890
            </Typography>
          </Grid>
          <Grid item xs={12} md={4}>
            <Typography variant="h6" gutterBottom>
              Explore
            </Typography>
            <Typography variant="body2">
              <Link href="#" style={linkStyle}>
                Destinations
              </Link>
            </Typography>
            <Typography variant="body2">
              <Link href="#" style={linkStyle}>
                Activities
              </Link>
            </Typography>
            <Typography variant="body2">
              <Link href="#" style={linkStyle}>
                Blog
              </Link>
            </Typography>
          </Grid>
        </Grid>
      </Container>
    </footer>
  );
};

export default Footer;
