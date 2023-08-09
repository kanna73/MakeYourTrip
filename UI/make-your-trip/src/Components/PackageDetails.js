import React, { useState } from 'react';
import axios from 'axios';


const PackageDetails = () => {

    // const [file, setFile] = useState();
    const [uploadedFileData, setUploadedFileData] = useState([]);
  
    // const saveFile = (e) => {
    //   setFile(e.target.files[0]);
    // };

    const [myObject, setMyObject] = useState({
        idInt: 1005,
        idString: 'string',
      });
    
    const getFileData = async () => {
        try {
          // const res = await axios.get("https://localhost:7290/api/PackageMasters/Get_all_PackageMaster", {
          //   responseType: "json",
          // });
          axios.post('https://localhost:7290/api/PackageMasters/Get_package_details', myObject)
          .then((res) => {
            // Handle the successful response
            console.log(res.data);
            console.log(res);
          // if (Array.isArray(res.data)) {
            console.log("Data received:", res.data);
            setUploadedFileData(res.data); 
          // } else {
            // console.log("Invalid data format received:", res.data);
          // }
          })
          // console.log(res);
          // if (Array.isArray(res.data)) {
          //   console.log("Data received:", res.data);
          //   setUploadedFileData(res.data); 
          // } else {
          //   console.log("Invalid data format received:", res.data);
          // }
        } catch (ex) {
          console.log("Error fetching data:", ex);
        }
      };

  return (
    <div>
         <button onClick={getFileData}>Get File Data</button>
    </div>
  )
}

export default PackageDetails