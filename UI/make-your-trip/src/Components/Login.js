// import React, { useState } from 'react';
// import "../Css/Login.css"

// const Login = () => {
//   const [name, setName] = useState('');
//   const [password, setPassword] = useState('');
// const [user, setUser] = useState({
//     username: '',
//     password: '',
//     token: '',
//     role: '',
//     name: '',
//     email: '',
//     phone: ''
//   });

// //   const handleNameChange = (event) => {
// //     // Allow only alphabets and spaces
// //     const regex = /^[A-Za-z\s]+$/;
// //     if (regex.test(event.target.value) || event.target.value === '') {
// //       setName(event.target.value);
// //     }
// //   };

// //   const handlePasswordChange = (event) => {
// //     const regex = /^(?=.[A-Z])(?=.[!@#$%^&])(?=.[0-9]).{8,}$/;
// //     if (regex.test(event.target.value) || event.target.value === '') {
// //       setPassword(event.target.value);
// //     }
// //   };

//   const handleLogin = () => {
//     console.log(user);
//     const apiUrl = "https://localhost:7290/api/Users/LogIN";
//     fetch(apiUrl, {
//       method: 'POST',
//       headers: {
//         accept: 'text/plain',
//         'Content-Type': 'application/json',
//       },
//       body: JSON.stringify({ ...user }),
//     })
//       .then(async (data) => {
//         if (data.status == 200) {
//           var myData = await data.json();

//           console.log(myData);
          
          
//         } else {
//           alert('Invalid username or password');
//         }
//       })
//       .catch((err) => {
//         console.log(err.error);
//       }); 
//   };

//   const handleSignup = () => {
//     // Handle signup logic here
//   };

//   const handleClear = () => {
//     setName('');
//     setPassword('');
//   };

//   return (
//     <div className="container">
//       <h2>Login</h2>
//       <form>
//         <label htmlFor="name">Name</label>
//         <input
//           type="text"
//           id="name"
//           value={name}
//             onChange={(e) => setUser({ ...user, username: e.target.value })}
//         />

//         <label htmlFor="password">Password</label>
//         <input
//           type="password"
//           id="password"
//           value={password}
//              onChange={(e) => setUser({ ...user, password: e.target.value })}
//         />

//         <button onClick={handleLogin}>Login</button>
//         <button onClick={handleSignup}>Signup</button>
//         <button className="clear-button" onClick={handleClear}>
//           Clear
//         </button>
//       </form>
//     </div>
//   );
// };

// export default Login;

// import React, { useState } from 'react';
// import styles from "../Css/Login.module.css"
// import Signup from './Signup';
// import { useNavigate } from 'react-router-dom';

// const Login = () => {
//   const [user, setUser] = useState({
//     username: '',
//     password: '',
//     token: '',
//     role: '',
//     name: '',
//     email: '',
//     phone: ''
//   });
//     var navigate=useNavigate();


//   const handleLogin = () => {
//     console.log(user);
//     const apiUrl = "https://localhost:7290/api/Users/LogIN";
//     fetch(apiUrl, {
//       method: 'POST',
//       headers: {
//         accept: 'text/plain',
//         'Content-Type': 'application/json',
//       },
//       body: JSON.stringify({ ...user }),
//     })
//       .then(async (data) => {
//         if (data.status === 200) {
//           var myData = await data.json();
//           console.log(myData);
//         } else {
//           alert('Invalid username or password');
//         }
//       })
//       .catch((err) => {
//         console.log(err.error);
//       });
//   };

//   const handleSignup = () => {
//             navigate('signup');
// };

//   const handleClear = () => {
//     setUser({
//       username: '',
//       password: '',
//       token: '',
//       role: '',
//       name: '',
//       email: '',
//       phone: ''
//     });
//   };

//   return (
//     <div className={styles.Body}> 

//     <div className={styles.container}>
//       <h2>Login</h2>
//       <form>
//         <label htmlFor="name">Name</label>
//         <input
//           type="text"
//           id="name"
//           value={user.username}
//           onChange={(e) => setUser({ ...user, username: e.target.value })}
//         />

//         <label htmlFor="password">Password</label>
//         <input
//           type="password"
//           id="password"
//           value={user.password}
//           onChange={(e) => setUser({ ...user, password: e.target.value })}
//         />

//         <button className={styles.Login} type="button" onClick={handleLogin}>Login</button>
//         <button className={styles.clear_button} type="button" onClick={handleClear}>
//           Clear
//         </button>
//         <button className={styles.Signup} type="button" onClick={handleSignup}>Signup</button>
//       </form>
//     </div>
//     </div>

//   );
// };

// export default Login;

// import React, { useState } from 'react';
// import styles from '../Css/Login.module.css';
// import Signup from './Signup';
// import { useNavigate } from 'react-router-dom';

// const Login = () => {
//   const [user, setUser] = useState({
//     username: '',
//     password: '',
//     token: '',
//     role: '',
//     name: '',
//     email: '',
//     phone: '',
//   });
//   const [nameError, setNameError] = useState('');
//   const [passwordError, setPasswordError] = useState('');

//   var navigate = useNavigate();

//   const handleLogin = () => {
//     console.log(user);
//     const apiUrl = 'https://localhost:7290/api/Users/LogIN';
//     fetch(apiUrl, {
//       method: 'POST',
//       headers: {
//         accept: 'text/plain',
//         'Content-Type': 'application/json',
//       },
//       body: JSON.stringify({ ...user }),
//     })
//       .then(async (data) => {
//         if (data.status === 200) {
//           var myData = await data.json();
//           console.log(myData);
//         } else {
//           alert('Invalid username or password');
//         }
//       })
//       .catch((err) => {
//         console.log(err.error);
//       });
//   };

//   const handleSignup = () => {
//     navigate('signup');
//   };

//   const handleClear = () => {
//     setUser({
//       username: '',
//       password: '',
//       token: '',
//       role: '',
//       name: '',
//       email: '',
//       phone: '',
//     });
//     setNameError('');
//     setPasswordError('');
//   };

//   const handleNameChange = (e) => {
//     const namePattern = /^[a-zA-Z\s]+$/;
//     const { value } = e.target;
//     setUser({ ...user, username: value });

//     if (!namePattern.test(value)) {
//       setNameError('Name should only contain alphabets and spaces');
//     } else {
//       setNameError('');
//     }
//   };

//   const handlePasswordChange = (e) => {
//     const passwordPattern = /^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$/;
//     const { value } = e.target;
//     setUser({ ...user, password: value });

//     if (!passwordPattern.test(value)) {
//       setPasswordError(
//         'Password should have at least one uppercase letter, one number, and one special character (@$!%*#?&)'
//       );
//     } else {
//       setPasswordError('');
//     }
//   };

//   const isFormValid = !nameError && !passwordError && user.username && user.password;

//   return (
//     <div className={styles.Body}>
//       <div className={styles.container}>
//         <h2>Login</h2>
//         <form>
//           <label htmlFor="name">Name</label>
//           <input
//             type="text"
//             id="name"
//             value={user.username}
//             onChange={handleNameChange}
//           />
//           {nameError && <div style={{ color: 'red', fontSize: '14px', marginTop: '5px' }}>{nameError}</div>}

//           <label htmlFor="password">Password</label>
//           <input
//             type="password"
//             id="password"
//             value={user.password}
//             onChange={handlePasswordChange}
//           />
//           {passwordError && <div style={{ color: 'red', fontSize: '14px', marginTop: '5px' }}>{passwordError}</div>}

//           <button className={styles.Login} type="button" onClick={handleLogin} disabled={!isFormValid}>
//             Login
//           </button>
//           <button className={styles.clear_button} type="button" onClick={handleClear}>
//             Clear
//           </button>
//           <button className={styles.Signup} type="button" onClick={handleSignup}>
//             Signup
//           </button>
//         </form>
//       </div>
//     </div>
//   );
// };

// export default Login;



// import React, { useState,useContext } from 'react';
// import styles from '../Css/Login.module.css';
// import Signup from './Signup';
// import { useNavigate } from 'react-router-dom';
// import { ApiContext } from './ApiContextProvider';


// const Login = () => {

//   const { setUserRole, setUserToken, setUserName, setUserId } = useContext(ApiContext);
//   const [username, setUsername] = useState(''); // State for username input
//   const [password, setPassword] = useState(''); // State for password input

//   const [user, setUser] = useState({
//     username: '',
//     password: '',
//     token: '',
//     role: '',
//     name: '',
//     email: '',
//     phone: '',
//   });
//   const [nameError, setNameError] = useState('');
//   const [passwordError, setPasswordError] = useState('');
//   const [showRequiredMessage, setShowRequiredMessage] = useState(false);

//   var navigate = useNavigate();

//   const handleLogin = () => {
//     if (!user.username || !user.password) {
//       setShowRequiredMessage(true);
//       return;
//     }

//     if (nameError || passwordError) {
//       return;
//     }

//     setShowRequiredMessage(false);

//     console.log(user);

//     const apiUrl = 'https://localhost:7290/api/Users/LogIN';
//          fetch(apiUrl, {
//           method: 'POST',
//           headers: {
//            accept: 'text/plain',
//             'Content-Type': 'application/json',
//           },
//           body: JSON.stringify({ ...user }),
//          })
//           .then(async (data) => {
//             if (data.status === 200) {
//               var myData = await data.json();
//               console.log(myData);
//               setUserRole(myData.role);
//               setUserToken(myData.token);
//               setUserName(myData.username);
//               setUserId(myData.id);
        
        
//               sessionStorage.setItem('userRole', myData.role);
//               sessionStorage.setItem('userToken', myData.token);
//               sessionStorage.setItem('userName', myData.username);
//               sessionStorage.setItem('userId', myData.id);
//               navigate('/');


//             } else {
//              alert('Invalid username or password');
//            }
//          })
//           .catch((err) => {
//             console.log(err.error);
//            });
//         };

//   const handleSignup = () => {
//     navigate('/signup');
//   };

//   const handleClear = () => {
//     setUser({
//       username: '',
//       password: '',
//       token: '',
//       role: '',
//       name: '',
//       email: '',
//       phone: '',
//     });
//     setNameError('');
//     setPasswordError('');
//     setShowRequiredMessage(false);
//   };

//   const handleNameChange = (e) => {
//     // const namePattern = /^[a-zA-Z\s]+$/;
//     const { value } = e.target;
//     setUser({ ...user, username: value });

//     // if (!namePattern.test(value)) {
//     //   setNameError('Name should only contain alphabets and spaces');
//     // } else {
//     //   setNameError('');
//     // }
//   };

//   const handlePasswordChange = (e) => {
//     const passwordPattern = /^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$/;
//     const { value } = e.target;
//     setUser({ ...user, password: value });

//     if (!passwordPattern.test(value)) {
//       setPasswordError(
//         'Password should have at least one uppercase letter, one number, and one special character (@$!%*#?&)'
//       );
//     } else {
//       setPasswordError('');
//     }
//   };

//   const isFormValid = !nameError && !passwordError && user.username && user.password;

//   return (
//     <div className={styles.Body}>
//       <div className={styles.container}>
//         <h2>Login</h2>
//         <form>
//           <label htmlFor="name">Name</label>
//           <input
//             type="text"
//             id="name"
//             value={user.username}
//             onChange={handleNameChange}
//           />
//           {/* {showRequiredMessage && !user.username && <div style={{ color: 'red', fontSize: '14px', marginTop: '5px' }}>Name is required</div>}
//           {nameError && <div style={{ color: 'red', fontSize: '14px', marginTop: '5px' }}>{nameError}</div>} */}

//           <label htmlFor="password">Password</label>
//           <input
//             type="password"
//             id="password"
//             value={user.password}
//             onChange={handlePasswordChange}
//           />
//           {showRequiredMessage && !user.password && <div style={{ color: 'red', fontSize: '14px', marginTop: '5px' }}>Password is required</div>}
//           {passwordError && <div style={{ color: 'red', fontSize: '14px', marginTop: '5px' }}>{passwordError}</div>}

//           <button className={styles.Login} type="button" onClick={handleLogin} >
//             Login
//           </button>
//           <button className={styles.clear_button} type="button" onClick={handleClear}>
//             Clear
//           </button>
//           <button className={styles.Signup} type="button" onClick={handleSignup}>
//             Signup
//           </button>
//         </form>
//       </div>
//     </div>
//   );
// };

// export default Login;

import React, { useState, useContext } from 'react';
import { TextField, Button, Container, Grid, Typography, Box } from '@mui/material';
import { useNavigate } from 'react-router-dom';
import { ApiContext } from './ApiContextProvider';
import styles from '../Css/Login.module.css';

const Login = () => {
  const { setUserRole, setUserToken, setUserName, setUserId } = useContext(ApiContext);
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [showRequiredMessage, setShowRequiredMessage] = useState(false);
  const [passwordError, setPasswordError] = useState('');

  var navigate = useNavigate();

  const handleLogin = () => {
    if (!username || !password) {
      setShowRequiredMessage(true);
      return;
    }

    if (passwordError) {
      return;
    }

    setShowRequiredMessage(false);

    const apiUrl = 'https://localhost:7290/api/Users/LogIN';
    fetch(apiUrl, {
      method: 'POST',
      headers: {
        accept: 'text/plain',
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({ username, password }),
    })
      .then(async (data) => {
        if (data.status === 200) {
          var myData = await data.json();
          setUserRole(myData.role);
          setUserToken(myData.token);
          setUserName(myData.username);
          setUserId(myData.id);

          sessionStorage.setItem('userRole', myData.role);
          sessionStorage.setItem('userToken', myData.token);
          sessionStorage.setItem('userName', myData.username);
          sessionStorage.setItem('userId', myData.id);
          alert('Login successfully');

          navigate('/');
        } else {
          alert('Invalid username or password');
        }
      })
      .catch((err) => {
        console.log(err.error);
      });
  };

  const handleSignup = () => {
    navigate('/signup');
  };

  const handleClear = () => {
    setUsername('');
    setPassword('');
    setShowRequiredMessage(false);
  };

  const handlePasswordChange = (e) => {
    const passwordPattern = /^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$/;
    const { value } = e.target;
    setPassword(value);

    if (!passwordPattern.test(value)) {
      setPasswordError(
        'Password should have at least one uppercase letter, one number, and one special character (@$!%*#?&)'
      );
    } else {
      setPasswordError('');
    }
  };

  const isFormValid = !passwordError && username && password;

  return (
    <Box className={styles.container}>
      <Container maxWidth="sm">
        <Typography variant="h4" align="center" gutterBottom>
          Login
        </Typography>
        <Box mt={2}>
          <TextField
            fullWidth
            id="username"
            label="Username"
            value={username}
            onChange={(e) => setUsername(e.target.value)}
            error={showRequiredMessage && !username}
            helperText={showRequiredMessage && !username ? 'Username is required' : ''}
          />
        </Box>
        <Box mt={2}>
          <TextField
            fullWidth
            id="password"
            label="Password"
            type="password"
            value={password}
            onChange={handlePasswordChange}
            error={showRequiredMessage && !password}
            helperText={showRequiredMessage && !password ? 'Password is required' : passwordError}
          />
        </Box>
        <Box mt={2}>
          <Button variant="contained" onClick={handleLogin} disabled={!isFormValid} fullWidth>
            Login
          </Button>
        </Box>
        <Box mt={1}>
          <Button variant="contained" onClick={handleClear} fullWidth>
            Clear
          </Button>
        </Box>
        <Box mt={1}>
          <Button variant="contained" onClick={handleSignup} fullWidth>
            Signup
          </Button>
        </Box>
      </Container>
    </Box>
  );
};

export default Login;

