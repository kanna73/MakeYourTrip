// Preloader.js
import React from 'react';
import styles from'../Css/Preloader.module.css'; 
import Loader from '../Assests/1480.gif';

const Preloader = () => {
  return (
    <div className={styles.preloader}>
      <img src={Loader} alt='Loading...'></img>
    </div>
  );
};

export default Preloader;