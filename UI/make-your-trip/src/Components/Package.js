import React, { useState,useEffect } from 'react';
import axios from 'axios';


const Package = () => {

    // const [file, setFile] = useState();
    const [uploadedFileData, setUploadedFileData] = useState();
  
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
            setUploadedFileData(res?.data);
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
      useEffect(() => {
       
       
        getFileData();
       
      }, []);

  return (
    <div>
         <button onClick={getFileData}>Get File Data</button>
         {/* {uploadedFileData.length > 0 && ( */}
         <div>
      <button onClick={getFileData}>Get File Data</button>
      {uploadedFileData && (
        <div>
          <h2>Uploaded File Data</h2>
          <table>
            <thead>
              <tr>
                <th>Package ID</th>
                <th>Package Price</th>
                <th>Image</th>
                <th>Travel Agent ID</th>
                <th>Region</th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <td>{uploadedFileData.id}</td>
                <td>{uploadedFileData.packagePrice}</td>
                <td>
                  {uploadedFileData.imagepath && (
                    <img
                      src={`data:image/jpeg;base64,${uploadedFileData.imagepath}`}
                      alt={`Image`}
                      style={{ maxWidth: '100%', maxHeight: '100px' }}
                    />
                  )}
                </td>
                <td>{uploadedFileData.travelAgentId}</td>
                <td>{uploadedFileData.region}</td>
              </tr>
            </tbody>
          </table>
        </div>
      )}
    </div>
    </div> 
  )
}

export default Package