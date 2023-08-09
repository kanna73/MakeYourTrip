// HomePage.js
import React from 'react';
import service1 from "../Assests/service1.jpg"
import coverimage from "../Assests/cover1.jpg"
import service2 from "../Assests/service2.jpg"
import service3 from "../Assests/service3.jpg"

const Landing = () => {
  const services = [
    {
      title: 'Service 1',
      description: 'Description of Service 1',
      image: service1, // Replace with actual image URL
    },
    {
      title: 'Service 2',
      description: 'Description of Service 2',
      image: service2, // Replace with actual image URL
    },
    {
      title: 'Service 3',
      description: 'Description of Service 3',
      image: service3, // Replace with actual image URL
    },
    
    
    // Add more services as needed
  ];

  const styles = {
    container: {
      padding: '20px',
      fontFamily: 'Arial, sans-serif',
    },
    coverImage: {
      width: '100%',
      height: '800px', // Adjust the height as needed
      objectFit: 'cover',
    },
    heading: {
      textAlign: 'center',
      fontSize: '24px',
      fontWeight: 'bold',
      margin: '20px 0',
    },
    serviceCard: {
      display: 'flex',
      flexDirection: 'column',
      alignItems: 'center',
      border: '1px solid #ccc',
      borderRadius: '8px',
      padding: '30px',
      margin: '10px',
      width: '350px',
      transition: 'transform 0.3s ease-in-out',
    },
    cardImage: {
      width: '200px',
      height: '200px',
      objectFit: 'cover',
    //   borderRadius: '%',
      marginBottom: '10px',
    },
    cardDescription: {
      textAlign: 'center',
      fontSize: '14px',
    },
  };

  return (
    <div style={styles.container}>
      <img
        src={coverimage} // Replace with your actual cover image URL
        alt="Cover"
        style={styles.coverImage}
      />
      <h1 style={styles.heading}>Our Services</h1>
      <div style={{ display: 'flex', justifyContent: 'center', flexWrap: 'wrap' }}>
        {services.map((service, index) => (
          <div key={index} style={styles.serviceCard}>
            <img src={service.image} alt={service.title} style={styles.cardImage} />
            <h3>{service.title}</h3>
            <p style={styles.cardDescription}>{service.description}</p>
          </div>
        ))}
      </div>
    </div>
  );
};

export default Landing;

