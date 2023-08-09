// import React, { useState,useEffect } from 'react';
// import axios from 'axios';
// // import styles from "../Css/Gallery.module.css"

// const Gallery = () => {
//     const images = [
//         'image1.jpg',
//         'image2.jpg',
//         'image3.jpg',
//         // Add more image URLs here
//       ];
//       const [uploadedFileData, setUploadedFileData] = useState([]);

    
//       const [currentIndex, setCurrentIndex] = useState(0);
    
//       const nextSlide = () => {
//         setCurrentIndex((prevIndex) => (prevIndex + 1) % uploadedFileData.length);
//       };
    
//       const prevSlide = () => {
//         setCurrentIndex((prevIndex) => (prevIndex - 1 + uploadedFileData.length) % uploadedFileData.length);
//       };
//       const getGalleryeData = async () => {
//         try {
//           // const res = await axios.get("https://localhost:7290/api/PackageMasters/Get_all_PackageMaster", {
//           //   responseType: "json",
//           // });
//           const res = await  axios.get('https://localhost:7290/api/PostGalleries/Get_all_PostGallery',{
//             responseType: "json",
//           });
          
//             // Handle the successful response
//             console.log(res.data);
//             console.log(res);
//           // if (Array.isArray(res.data)) {
//             console.log("Data received:", res.data);
//             setUploadedFileData(res.data);
//             // } else {
//             // console.log("Invalid data format received:", res.data);
//           // }
         
//           // console.log(res);
//           // if (Array.isArray(res.data)) {
//           //   console.log("Data received:", res.data);
//           //   setUploadedFileData(res.data); 
//           // } else {
//           //   console.log("Invalid data format received:", res.data);
//           // }
//         } catch (ex) {
//           console.log("Error fetching data:", ex);
//         }
//       };
//       useEffect(() => {
       
       
//         getGalleryeData();
       
//       }, []);
    
//       return (
//         <div className={styles.slider}>
//           {uploadedFileData.map((image, index) => (
//             <div
//               key={index}
//               className={index === currentIndex ? 'slide active' : 'slide'}
//               style={{ backgroundImage: `url(data:image/jpeg;base64,${image.adminimage})` }}
//               ></div>
//           ))}
//           <button className={styles.prev_button} onClick={prevSlide}>
//             &#10094;
//           </button>
//           <button className={styles.next_button} onClick={nextSlide}>
//             &#10095;
//           </button>
//         </div>
//       );
//     };


// export default Gallery


// import React, { useState, useEffect } from 'react';
// import axios from 'axios';

// const Gallery = () => {
//   const images = [
//     'image1.jpg',
//     'image2.jpg',
//     'image3.jpg',
//     // Add more image URLs here
//   ];
//   const [uploadedFileData, setUploadedFileData] = useState([]);
//   const [currentIndex, setCurrentIndex] = useState(0);

//   const nextSlide = () => {
//     if (uploadedFileData.length > 0) {
//       setCurrentIndex((prevIndex) => (prevIndex + 1) % uploadedFileData.length);
//     }
//   };
  

//   const prevSlide = () => {
//     setCurrentIndex((prevIndex) => (prevIndex - 1 + uploadedFileData.length) % uploadedFileData.length);
//   };
  
//   const getGalleryData = async () => {
//     try {
//       const res = await axios.get('https://localhost:7290/api/PostGalleries/Get_all_PostGallery', {
//         responseType: 'json',
//       });
//       console.log(res.data);
//       console.log(res);
//       setUploadedFileData(res.data);
//     } catch (ex) {
//       console.log('Error fetching data:', ex);
//     }
//   };

//   useEffect(() => {
//     getGalleryData();
//   }, []);

//   return (
//     <div style={{ display: 'flex', overflow: 'hidden', position: 'relative' }}>
//       {uploadedFileData.map((image, index) => (
//         <div
//           key={index}
//           style={{
//             minWidth: '100%',
//             height: '100vh',
//             backgroundSize: 'cover',
//             backgroundRepeat: 'no-repeat',
//             transition: 'transform 0.3s ease',
//             backgroundImage: `url(data:image/jpeg;base64,${image.adminimage})`,
//             transform: index === currentIndex ? 'translateX(0)' : null,
//           }}
//         ></div>
//       ))}
//       <button
//         style={{
//           position: 'absolute',
//           top: '50%',
//           transform: 'translateY(-50%)',
//           fontSize: '24px',
//           cursor: 'pointer',
//           left: '10px',
//         }}
//         onClick={prevSlide}
//       >
//         &#10094;
//       </button>
//       <button
//         style={{
//           position: 'absolute',
//           top: '50%',
//           transform: 'translateY(-50%)',
//           fontSize: '24px',
//           cursor: 'pointer',
//           right: '10px',
//         }}
//         onClick={nextSlide}
//       >
//         &#10095;
//       </button>
//     </div>
//   );
// };

// export default Gallery;


// import React, { useState, useEffect } from 'react';
// import axios from 'axios';

// const Gallery = () => {
//   const [uploadedFileData, setUploadedFileData] = useState([]);

//   const getGalleryData = async () => {
//     try {
//       const res = await axios.get('https://localhost:7290/api/PostGalleries/Get_all_PostGallery', {
//         responseType: 'json',
//       });
//       console.log(res.data);
//       console.log(res);
//       setUploadedFileData(res.data);
//     } catch (ex) {
//       console.log('Error fetching data:', ex);
//     }
//   };

//   useEffect(() => {
//     getGalleryData();
//   }, []);

//   return (
//     <div id="carouselExample" className="carousel slide" data-bs-ride="carousel">
//       <div className="carousel-inner">
//         {uploadedFileData.map((image, index) => (
//           <div key={index} className={`carousel-item ${index === 0 ? 'active' : ''}`}>
//             <img src={`data:image/jpeg;base64,${image.adminimage}`} className="d-block w-100" alt={`Slide ${index}`} />
//           </div>
//         ))}
//       </div>
//       <button className="carousel-control-prev" type="button" data-bs-target="#carouselExample" data-bs-slide="prev">
//         <span className="carousel-control-prev-icon" aria-hidden="true"></span>
//         <span className="visually-hidden">Previous</span>
//       </button>
//       <button className="carousel-control-next" type="button" data-bs-target="#carouselExample" data-bs-slide="next">
//         <span className="carousel-control-next-icon" aria-hidden="true"></span>
//         <span className="visually-hidden">Next</span>
//       </button>
//     </div>
//   );
// };

// export default Gallery;


// import React, { useState, useEffect } from 'react';
// import axios from 'axios';

// const Gallery = () => {
//   const [uploadedFileData, setUploadedFileData] = useState([]);

//   const getGalleryData = async () => {
//     try {
//       const res = await axios.get('https://localhost:7290/api/PostGalleries/Get_all_PostGallery', {
//         responseType: 'json',
//       });
//       console.log(res.data);
//       console.log(res);
//       setUploadedFileData(res.data);
//     } catch (ex) {
//       console.log('Error fetching data:', ex);
//     }
//   };

//   useEffect(() => {
//     getGalleryData();
//   }, []);

//   return (
//     <div id="carouselExample" className="carousel slide" data-bs-ride="carousel">
//       <div className="carousel-inner">
//         {uploadedFileData.map((image, index) => (
//           <div key={index} className={`carousel-item ${index === 0 ? 'active' : ''}`}>
//             <img src={`data:image/jpeg;base64,${image.adminimage}`} className="d-block w-100" alt={`Slide ${index}`} />
//           </div>
//         ))}
//       </div>
//     </div>
//   );
// };

// export default Gallery;

// import React, { useState, useEffect } from 'react';
// import axios from 'axios';

// const Gallery = () => {
//   const [uploadedFileData, setUploadedFileData] = useState([]);
//   const [currentIndex, setCurrentIndex] = useState(0);

//   const getGalleryData = async () => {
//     try {
//       const res = await axios.get('https://localhost:7290/api/PostGalleries/Get_all_PostGallery', {
//         responseType: 'json',
//       });
//       console.log(res.data);
//       console.log(res);
//       setUploadedFileData(res.data);
//     } catch (ex) {
//       console.log('Error fetching data:', ex);
//     }
//   };

//   useEffect(() => {
//     getGalleryData();
//   }, []);

//   useEffect(() => {
//     const interval = setInterval(() => {
//       setCurrentIndex((prevIndex) => (prevIndex + 1) % uploadedFileData.length);
//     }, 5000); // Change the value to the desired interval in milliseconds (e.g., 5000ms = 5 seconds)

//     return () => clearInterval(interval);
//   }, [uploadedFileData]);

//   return (
//     <div id="carouselExample" className="carousel slide" data-bs-ride="carousel">
//       <div className="carousel-inner">
//         {uploadedFileData.map((image, index) => (
//           <div key={index} className={`carousel-item ${index === currentIndex ? 'active' : ''}`}>
//             <img src={`data:image/jpeg;base64,${image.adminimage}`} className="d-block w-100" alt={`Slide ${index}`} />
//           </div>
//         ))}
//       </div>
//     </div>
//   );
// };

// export default Gallery;

import React, { useState, useEffect } from 'react';
import axios from 'axios';
import styles from "../Css/Gallery.module.css"


const Gallery = () => {
  const [uploadedFileData, setUploadedFileData] = useState([]);
  const [currentIndex, setCurrentIndex] = useState(0);

  const getGalleryData = async () => {
    try {
      const res = await axios.get('https://localhost:7290/api/PostGalleries/Get_all_PostGallery', {
        responseType: 'json',
      });
      console.log(res.data);
      console.log(res);
      // Filter only the images with imageType: "imageslider"
      // const filteredImages = res.data.filter((image) => image.imageType === 'imageslider');
      setUploadedFileData(res.data);
      console.log(uploadedFileData);
    } catch (ex) {
      console.log('Error fetching data:', ex);
    }
  };

  useEffect(() => {
    getGalleryData();
  }, []);

  // useEffect(() => {
  //   const interval = setInterval(() => {
  //     setCurrentIndex((prevIndex) => (prevIndex + 1) % uploadedFileData.length);
  //   }, 5000); // Change the value to the desired interval in milliseconds (e.g., 5000ms = 5 seconds)

  //   return () => clearInterval(interval);
  // }, [uploadedFileData]);

  return (
    // <div id="carouselExample" className="carousel slide" data-bs-ride="carousel">
    //   <div className="carousel-inner">
    //     {uploadedFileData.map((image, index) => (
    //       <div key={index} className={`carousel-item ${index === currentIndex ? 'active' : ''}`}>
    //         <img src={`data:image/jpeg;base64,${image.adminimage}`} className="d-block w-100" alt={`Slide ${index}`} />
    //       </div>
    //     ))}
    //   </div>
    // </div>
    <div>
      <h1>Our Gallery</h1>
      <div className={styles.card_container}>
        {uploadedFileData.map((item, index) => (
          <div className={styles.card} key={index}>
            <img
              src={`data:image/jpeg;base64,${item.adminimage}`}
              alt={`Image ${index + 1}`}
              className={styles.card_image}
            />
            <div className={styles.card_details}>
              {/* <p>Package ID: {item.id}</p>
              <p>Package Price: {item.packagePrice}</p>
              <p>Region: {item.region}</p>
              <button className={styles.Bookbutton} type="button" onClick={handleBook}>Book</button> */}

              {/* Add other data here */}
            </div>
          </div>
        ))}
      </div>
    </div>
  );
};



export default Gallery;




