// import React, { useState } from 'react';
// import styles from '../Css/Signup.module.css'; // Create a CSS file for RegisterPage styles
// import { useNavigate } from 'react-router-dom';


// const Signup = () => {
//   const [formData, setFormData] = useState({
//     username: '',
//     phone: '',
//     email: '',
//     name: '',
//     userPassword: '',
//     role: '', // Default role is 'User'
//   });

//   const [passwordError, setPasswordError] = useState('');

//   const handleInputChange = (e) => {
//     const { name, value } = e.target;
//     setFormData({
//       ...formData,
//       [name]: value,
//     });
//   };
//   var navigate=useNavigate();


//   const handleSubmit = (e) => {
//     e.preventDefault();
//     // Validate form data and perform registration logic here
//     console.log(formData);
//     const apiUrl = "https://localhost:7290/api/Users/Register";
//     fetch(apiUrl, {
//       method: 'POST',
//       headers: {
//         accept: 'text/plain',
//         'Content-Type': 'application/json',
//       },
//       body: JSON.stringify({ ...formData }),
//     })
//       .then(async (data) => {
//         if (data.status === 201) {
//           var myData = await data.json();
//           console.log(myData);
//         } else {
//           alert('Invalid username or password');
//           var myData = await data.json();
//           console.log(myData);
//         }
//       })
//       .catch((err) => {
//         console.log(err.error);
//       });
//   };

//   const handleConfirmPassword = () => {
//     if (formData.password !== formData.confirmPassword) {
//       return false;
//     }
//     return true;
//   };

//   const validatePassword = (password) => {
//     // Use a regular expression to validate the password
//     const passwordPattern = /^(?=.[a-z])(?=.[A-Z])(?=.\d)(?=.[@$!%?&])[A-Za-z\d@$!%?&]{8,}$/;
//     return passwordPattern.test(password);
//   };

//   const handlePasswordChange = (e) => {
//     const { value } = e.target;
//     setFormData({
//       ...formData,
//       userPassword: value,
//     });
//     if (!validatePassword(value)) {
//       setPasswordError(
//         'Password must contain at least one uppercase letter, one lowercase letter, one number, and one special character.'
//       );
//     } else {
//       setPasswordError('');
//     }
//   };
//   var handleClear=()=>{
//     setFormData({
//         username: '',
//         phone: '',
//         email: '',
//         name: '',
//         userPassword: '',
//         role: ''
//       });
//   }
//   var handleLogin=()=>{
//     navigate('/');

//   }

//   return (
//     <div className={styles.register_page}>
      
//       <div className={styles.register_form}>
//         <h2>Register</h2>
//         <form onSubmit={handleSubmit}>
//           <div className={styles.form_group}>
//             <label htmlFor="username">Username:</label>
//             <input
//               type="text"
//               id="username"
//               name="username"
//               value={formData.username}
//               onChange={handleInputChange}
//               required
//             />
//           </div>
//           <div className={styles.form_group}>
//             <label htmlFor="phone">Phone:</label>
//             <input
//               type="text"
//               id="phone"
//               name="phone"
//               value={formData.phone}
//               onChange={handleInputChange}
//               required
//             />
//           </div>
//           <div className={styles.form_group}>
//             <label htmlFor="email">Email:</label>
//             <input
//               type="email"
//               id="email"
//               name="email"
//               value={formData.email}
//               onChange={handleInputChange}
//               required
//             />
//           </div>
//           <div className={styles.form_group}>
//             <label htmlFor="name">Name:</label>
//             <input
//               type="text"
//               id="name"
//               name="name"
//               value={formData.name}
//               onChange={handleInputChange}
//               required
//             />
//           </div>
//           <div className={styles.form_group}>
//             <label htmlFor="password">Password:</label>
//             <input
//               type="password"
//               id="password"
//               name="password"
//               value={formData.userPassword}
//               onChange={handlePasswordChange}
//               required
//             />
//             {passwordError && <span className="error">{passwordError}</span>}
//           </div>
         
//           <div className={styles.form_group}>
//             <label htmlFor="role">Role:</label>
//             <select
//               id="role"
//               name="role"
//               value={formData.role}
//               onChange={handleInputChange}
//               required
//             >
//               <option value="User">User</option>
//               <option value="Agent">Agent</option>
//             </select>
//           </div>
//           <div className={styles.form_group}>
//             <button className={styles.Register} type="submit">Register</button>
//             <button className={styles.Login} type="button" onClick={handleLogin}>Login</button>
//             <button className={styles.Clear} type="button" onClick={handleClear}>Clear</button>
//           </div>
//         </form>
//       </div>
//     </div>
//   );
// };

// export default  Signup 


// import React, { useState } from 'react';
// import styles from '../Css/Signup.module.css';
// import { useNavigate } from 'react-router-dom';

// const Signup = () => {
//   const [formData, setFormData] = useState({
//     username: '',
//     phone: '',
//     email: '',
//     name: '',
//     userPassword: '',
//     role: 'User',
//   });

//   const [nameError, setNameError] = useState('');
//   const [passwordError, setPasswordError] = useState('');
//   const [emailError, setEmailError] = useState('');
//   const [phoneError, setPhoneError] = useState('');

//   const navigate = useNavigate();

//   const handleInputChange = (e) => {
//     const { name, value } = e.target;
//     setFormData({
//       ...formData,
//       [name]: value,
//     });
//   };

//   var handleClear=()=>{
//         setFormData({
//             username: '',
//              phone: '',
//              email: '',
//            name: '',
//            userPassword: '',
//             role: ''
//          });
//        }

//   const handleSubmit = (e) => {
//     e.preventDefault();

//     if (!validateName(formData.name)) {
//       setNameError('Name should only contain alphabets and spaces');
//       return;
//     } else {
//       setNameError('');
//     }

//     if (!validatePassword(formData.userPassword)) {
//       setPasswordError(
//         'Password must contain at least one uppercase letter, one lowercase letter, one number, and one special character.'
//       );
//       return;
//     } else {
//       setPasswordError('');
//     }

//     if (!validateEmail(formData.email)) {
//       setEmailError('Invalid email format');
//       return;
//     } else {
//       setEmailError('');
//     }

//     if (!validatePhone(formData.phone)) {
//       setPhoneError('Phone number must be 10 digits');
//       return;
//     } else {
//       setPhoneError('');
//     }

//     // Perform registration logic here
//     console.log(formData);
//     const apiUrl = 'https://localhost:7290/api/Users/Register';
//     fetch(apiUrl, {
//       method: 'POST',
//       headers: {
//         accept: 'text/plain',
//         'Content-Type': 'application/json',
//       },
//       body: JSON.stringify({ ...formData }),
//     })
//       .then(async (data) => {
//         if (data.status === 201) {
//           var myData = await data.json();
//           console.log(myData);
//         } else {
//           alert('Invalid username or password');
//           var myData = await data.json();
//           console.log(myData);
//         }
//       })
//       .catch((err) => {
//         console.log(err.error);
//       });
//   };

//   const validateName = (name) => /^[a-zA-Z\s]+$/.test(name);
//   const validatePassword = (password) =>
//     /^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$/.test(password);
//   const validateEmail = (email) => /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email);
//   const validatePhone = (phone) => /^\d{10}$/.test(phone);

//   const isFormValid =
//     !nameError && !passwordError && !emailError && !phoneError && formData.name && formData.userPassword && formData.email && formData.phone;

//   const handleLogin = () => {
//     navigate('/');
//   };

//   return (
//     <div className={styles.register_page}>
//       <div className={styles.register_form}>
//         <h2>Register</h2>
//         <form onSubmit={handleSubmit}>
//           <div className={styles.form_group}>
//             <label htmlFor="username">Username:</label>
//             <input
//               type="text"
//               id="username"
//               name="username"
//               value={formData.username}
//               onChange={handleInputChange}
//               required
//             />
//           </div>
//           <div className={styles.form_group}>
//             <label htmlFor="phone">Phone:</label>
//             <input
//               type="text"
//               id="phone"
//               name="phone"
//               value={formData.phone}
//               onChange={handleInputChange}
//               required
//             />
//             {phoneError && <span className={styles.error}>{phoneError}</span>}
//           </div>
//           <div className={styles.form_group}>
//             <label htmlFor="email">Email:</label>
//             <input
//               type="email"
//               id="email"
//               name="email"
//               value={formData.email}
//               onChange={handleInputChange}
//               required
//             />
//             {emailError && <span className={styles.error}>{emailError}</span>}
//           </div>
//           <div className={styles.form_group}>
//             <label htmlFor="name">Name:</label>
//             <input
//               type="text"
//               id="name"
//               name="name"
//               value={formData.name}
//               onChange={handleInputChange}
//               required
//             />
//             {nameError && <span className={styles.error}>{nameError}</span>}
//           </div>
//           <div className={styles.form_group}>
//             <label htmlFor="password">Password:</label>
//             <input
//               type="password"
//               id="password"
//               name="userPassword"
//               value={formData.userPassword}
//               onChange={handleInputChange}
//               required
//             />
//             {passwordError && <span className={styles.error}>{passwordError}</span>}
//           </div>

//           <div className={styles.form_group}>
//             <label htmlFor="role">Role:</label>
//             <select
//               id="role"
//               name="role"
//               value={formData.role}
//               onChange={handleInputChange}
//               required
//             >
//               <option value="User">User</option>
//               <option value="Agent">Agent</option>
//             </select>
//           </div>
//           <div className={styles.form_group}>
//             <button className={styles.Register} type="submit" disabled={!isFormValid}>
//               Register
//             </button>
//             <button className={styles.Login} type="button" onClick={handleLogin}>
//               Login
//             </button>
//             <button className={styles.Clear} type="button" onClick={handleClear}>
//               Clear
//             </button>
//           </div>
//         </form>
//       </div>
//     </div>
//   );
// };

// export default Signup;

    

// import React, { useState } from 'react';
// import styles from '../Css/Signup.module.css';
// import { useNavigate } from 'react-router-dom';

// const Signup = () => {
//   const [formData, setFormData] = useState({
//     username: '',
//     phone: '',
//     email: '',
//     name: '',
//     userPassword: '',
//     role: 'User',
//   });

//   const [nameError, setNameError] = useState('');
//   const [passwordError, setPasswordError] = useState('');
//   const [emailError, setEmailError] = useState('');
//   const [phoneError, setPhoneError] = useState('');

//   const navigate = useNavigate();

//   const handleInputChange = (e) => {
//     const { name, value } = e.target;
//     setFormData({
//       ...formData,
//       [name]: value,
//     });

//     // Perform validation checks and update error messages
//     if (name === 'name') {
//       setNameError(!validateName(value) ? 'Name should only contain alphabets and spaces' : '');
//     } else if (name === 'userPassword') {
//       setPasswordError(
//         !validatePassword(value)
//           ? 'Password must contain at least one uppercase letter, one lowercase letter, one number, and one special character.'
//           : ''
//       );
//     } else if (name === 'email') {
//       setEmailError(!validateEmail(value) ? 'Invalid email format' : '');
//     } else if (name === 'phone') {
//       setPhoneError(!validatePhone(value) ? 'Phone number must be 10 digits' : '');
//     }
//   };

//   const handleSubmit = (e) => {
//     e.preventDefault();

//     // Validate form data before submission
//     if (!validateName(formData.name)) {
//       setNameError('Name should only contain alphabets and spaces');
//       return;
//     } else {
//       setNameError('');
//     }

//     if (!validatePassword(formData.userPassword)) {
//       setPasswordError(
//         'Password must contain at least one uppercase letter, one lowercase letter, one number, and one special character.'
//       );
//       return;
//     } else {
//       setPasswordError('');
//     }

//     if (!validateEmail(formData.email)) {
//       setEmailError('Invalid email format');
//       return;
//     } else {
//       setEmailError('');
//     }

//     if (!validatePhone(formData.phone)) {
//       setPhoneError('Phone number must be 10 digits');
//       return;
//     } else {
//       setPhoneError('');
//     }

//     // Perform registration logic here
//     console.log(formData);
//     const apiUrl = 'https://localhost:7290/api/Users/Register';
//     fetch(apiUrl, {
//       method: 'POST',
//       headers: {
//         accept: 'text/plain',
//         'Content-Type': 'application/json',
//       },
//       body: JSON.stringify({ ...formData }),
//     })
//       .then(async (data) => {
//         if (data.status === 201) {
//           var myData = await data.json();
//           console.log(myData);
//         } else {
//           alert('Invalid username or password');
//           var myData = await data.json();
//           console.log(myData);
//         }
//       })
//       .catch((err) => {
//         console.log(err.error);
//       });
//   };

//   const validateName = (name) => /^[a-zA-Z\s]+$/.test(name);
//   const validatePassword = (password) =>
//     /^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$/.test(password);
//   const validateEmail = (email) => /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email);
//   const validatePhone = (phone) => /^\d{10}$/.test(phone);

//   const isFormValid =
//     !nameError && !passwordError && !emailError && !phoneError && formData.name && formData.userPassword && formData.email && formData.phone;

//   const handleLogin = () => {
//     navigate('/');
//   };
//   var handleClear=()=>{
//              setFormData({
//                  username: '',
//                  phone: '',
//                   email: '',
//                 name: '',
//                 userPassword: '',
//                  role: ''
//               });
//             }
  

//   return (
//     <div className={styles.register_page}>
//       <div className={styles.register_form}>
//         <h2>Register</h2>
//         <form onSubmit={handleSubmit}>
//           <div className={styles.form_group}>
//             <label htmlFor="username">Username:</label>
//             <input
//               type="text"
//               id="username"
//               name="username"
//               value={formData.username}
//               onChange={handleInputChange}
//               required
//             />
//           </div>
//           <div className={styles.form_group}>
//             <label htmlFor="phone">Phone:</label>
//             <input
//               type="text"
//               id="phone"
//               name="phone"
//               value={formData.phone}
//               onChange={handleInputChange}
//               required
//             />
//             {phoneError && <span className={styles.error}>{phoneError}</span>}
//           </div>
//           <div className={styles.form_group}>
//             <label htmlFor="email">Email:</label>
//             <input
//               type="email"
//               id="email"
//               name="email"
//               value={formData.email}
//               onChange={handleInputChange}
//               required
//             />
//             {emailError && <span className={styles.error}>{emailError}</span>}
//           </div>
//           <div className={styles.form_group}>
//             <label htmlFor="name">Name:</label>
//             <input
//               type="text"
//               id="name"
//               name="name"
//               value={formData.name}
//               onChange={handleInputChange}
//               required
//             />
//             {nameError && <span className={styles.error}>{nameError}</span>}
//           </div>
//           <div className={styles.form_group}>
//             <label htmlFor="password">Password:</label>
//             <input
//               type="password"
//               id="password"
//               name="userPassword"
//               value={formData.userPassword}
//               onChange={handleInputChange}
//               required
//             />
//             {passwordError && <span className={styles.error}>{passwordError}</span>}
//           </div>

//           <div className={styles.form_group}>
//             <label htmlFor="role">Role:</label>
//             <select
//               id="role"
//               name="role"
//               value={formData.role}
//               onChange={handleInputChange}
//               required
//             >
//               <option value="User">User</option>
//               <option value="Agent">Agent</option>
//             </select>
//           </div>
//           <div className={styles.form_group}>
//             <button className={styles.Register} type="submit" disabled={!isFormValid}>
//               Register
//             </button>
//             <button className={styles.Login} type="button" onClick={handleLogin}>
//               Login
//             </button>
//             <button className={styles.Clear} type="button" onClick={handleClear}>
//               Clear
//             </button>
//           </div>
//         </form>
//       </div>
//     </div>
//   );
// };

// export default Signup;

import React, { useState } from 'react';
import { Grid, TextField, Button, Container, Typography, Box } from '@mui/material';
import { useNavigate } from 'react-router-dom';
import styles from '../Css/Signup.module.css';

const Signup = () => {
  const [formData, setFormData] = useState({
    username: '',
    phone: '',
    email: '',
    name: '',
    userPassword: '',
    role: 'User',
  });

  const [nameError, setNameError] = useState('');
  const [passwordError, setPasswordError] = useState('');
  const [emailError, setEmailError] = useState('');
  const [phoneError, setPhoneError] = useState('');

  const navigate = useNavigate();

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setFormData({
      ...formData,
      [name]: value,
    });

    // Perform validation checks and update error messages
    if (name === 'name') {
      setNameError(!validateName(value) ? 'Name should only contain alphabets and spaces' : '');
    } else if (name === 'userPassword') {
      setPasswordError(
        !validatePassword(value)
          ? 'Password must contain at least one uppercase letter, one lowercase letter, one number, and one special character (@$!%*#?&)'
          : ''
      );
    } else if (name === 'email') {
      setEmailError(!validateEmail(value) ? 'Invalid email format' : '');
    } else if (name === 'phone') {
      setPhoneError(!validatePhone(value) ? 'Phone number must be 10 digits' : '');
    }
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    // Validate form data before submission
    if (!validateName(formData.name)) {
      setNameError('Name should only contain alphabets and spaces');
      return;
    } else {
      setNameError('');
    }

    if (!validatePassword(formData.userPassword)) {
      setPasswordError(
        'Password must contain at least one uppercase letter, one lowercase letter, one number, and one special character (@$!%*#?&)'
      );
      return;
    } else {
      setPasswordError('');
    }

    if (!validateEmail(formData.email)) {
      setEmailError('Invalid email format');
      return;
    } else {
      setEmailError('');
    }

    if (!validatePhone(formData.phone)) {
      setPhoneError('Phone number must be 10 digits');
      return;
    } else {
      setPhoneError('');
    }

    // Perform registration logic here
    console.log(formData);
    const apiUrl = 'https://localhost:7290/api/Users/Register';
    fetch(apiUrl, {
      method: 'POST',
      headers: {
        accept: 'text/plain',
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({ ...formData }),
    })
      .then(async (data) => {
        if (data.status === 201) {
          var myData = await data.json();
          console.log(myData);
          alert('Register successfully');

        } else {
          alert('Invalid username');
          var myData = await data.json();
          console.log(myData);
        }
      })
      .catch((err) => {
        console.log(err.error);
      });
  };

  const validateName = (name) => /^[a-zA-Z\s]+$/.test(name);
  const validatePassword = (password) =>
    /^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$/.test(password);
  const validateEmail = (email) => /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email);
  const validatePhone = (phone) => /^\d{10}$/.test(phone);

  const isFormValid =
    !nameError && !passwordError && !emailError && !phoneError && formData.name && formData.userPassword && formData.email && formData.phone;

  const handleLogin = () => {
    navigate('/');
  };

  var handleClear = () => {
    setFormData({
      username: '',
      phone: '',
      email: '',
      name: '',
      userPassword: '',
      role: '',
    });
  };

  return (
    <Box className={styles.register_page}>
      <Container maxWidth="sm">
        <div className={styles.register_form}>
          <Typography variant="h5" align="center" gutterBottom>
            Register
          </Typography>
          <form onSubmit={handleSubmit}>
            <Grid container spacing={2}>
              <Grid item xs={12}>
                <TextField
                  fullWidth
                  label="Username"
                  variant="outlined"
                  name="username"
                  value={formData.username}
                  onChange={handleInputChange}
                  required
                />
              </Grid>
              <Grid item xs={12}>
                <TextField
                  fullWidth
                  label="Phone"
                  variant="outlined"
                  name="phone"
                  value={formData.phone}
                  onChange={handleInputChange}
                  required
                  error={Boolean(phoneError)}
                  helperText={phoneError}
                />
              </Grid>
              <Grid item xs={12}>
                <TextField
                  fullWidth
                  label="Email"
                  variant="outlined"
                  name="email"
                  value={formData.email}
                  onChange={handleInputChange}
                  required
                  error={Boolean(emailError)}
                  helperText={emailError}
                />
              </Grid>
              <Grid item xs={12}>
                <TextField
                  fullWidth
                  label="Name"
                  variant="outlined"
                  name="name"
                  value={formData.name}
                  onChange={handleInputChange}
                  required
                  error={Boolean(nameError)}
                  helperText={nameError}
                />
              </Grid>
              <Grid item xs={12}>
                <TextField
                  fullWidth
                  label="Password"
                  variant="outlined"
                  type="password"
                  name="userPassword"
                  value={formData.userPassword}
                  onChange={handleInputChange}
                  required
                  error={Boolean(passwordError)}
                  helperText={passwordError}
                />
              </Grid>
              <Grid item xs={12}>
  <label htmlFor="role">Role:</label>
  <select
    id="role"
    name="role"
    value={formData.role}
    onChange={handleInputChange}
    required
     className={styles['custom-select']}
  >
    <option value="User">User</option>
    <option value="Agent">Agent</option>
  </select>
</Grid>
              <Grid item xs={12}>
                <Button
                  fullWidth
                  variant="contained"
                  color="primary"
                  type="submit"
                  disabled={!isFormValid}
                >
                  Register
                </Button>
              </Grid>
            </Grid>
          </form>
          <div className={styles.form_group}>
            <Button fullWidth variant="outlined" 
             color="primary" onClick={handleLogin} style={{ marginTop: '8px' }}
             >
              Login
            </Button>
            <Button fullWidth variant="outlined" color="secondary" onClick={handleClear} style={{ marginTop: '8px' }}>
              Clear
            </Button>
          </div>
        </div>
      </Container>
    </Box>
  );
};

export default Signup;

