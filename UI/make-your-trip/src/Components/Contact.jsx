// import React, {useRef} from 'react'
// import emailjs from '@emailjs/browser';

// const Contact = () => {
//     const form = useRef();

//     const sendEmail = (e) => {
//       e.preventDefault();
  
//       emailjs.sendForm('service_jqsyh7n', 
//       'template_03a5j4a',
//        form.current, 'jdH7Utyafx9fZxebW')
//         .then((result) => {
//             console.log(result.text);
//             alert("message sent");
//             form.current.reset(); 
//         }, (error) => {
//             console.log(error.text);
//         });
//     };
//   return (
      
//     <div className='Feedback_Form'>
//         <h1>Give Your Valuable Feedback :</h1>
//     <form ref={form} onSubmit={sendEmail}>
//       <label>Name</label>
//       <input type="text" name="user_name" />
//       <label>Email</label>
//       <input type="email" name="user_email" />
//       <label htmlFor='phone'>Phone:</label>
//           <input
//             type='tel'
//             id='phone'
//             name='phone'
//             required
//             pattern="[0-9]{10}"
//             title="Please enter a 10-digit phone number"
//           />
//       <label>Message</label>
//       <textarea name="message" />
//       <input type="submit" value="Send" />
//     </form>
//     </div>
//   )
// }

// export default Contact;

// import React, { useRef, useState } from 'react';
// import emailjs from '@emailjs/browser';

// const Contact = () => {
//   const form = useRef();
//   const [nameError, setNameError] = useState('');
//   const [emailError, setEmailError] = useState('');
//   const [phoneError, setPhoneError] = useState('');

//   const sendEmail = (e) => {
//     e.preventDefault();

//     if (!validateName(form.current.user_name.value)) {
//       setNameError('Name should only contain alphabets and spaces');
//       return;
//     } else {
//       setNameError('');
//     }

//     if (!validateEmail(form.current.user_email.value)) {
//       setEmailError('Invalid email format');
//       return;
//     } else {
//       setEmailError('');
//     }

//     if (!validatePhone(form.current.phone.value)) {
//       setPhoneError('Phone number must be 10 digits');
//       return;
//     } else {
//       setPhoneError('');
//     }

//     emailjs.sendForm('service_jqsyh7n', 'template_03a5j4a', form.current, 'jdH7Utyafx9fZxebW')
//       .then((result) => {
//         console.log(result.text);
//         alert("message sent");
//         form.current.reset();
//       }, (error) => {
//         console.log(error.text);
//       });
//   };

//   const validateName = (name) => /^[a-zA-Z\s]+$/.test(name);
//   const validateEmail = (email) => /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email);
//   const validatePhone = (phone) => /^\d{10}$/.test(phone);

//   const isFormValid =
//   !nameError && !emailError && !phoneError && form.current && form.current.user_name.value && form.current.user_email.value && form.current.phone.value;

//   return (
//     <div style={{ display: 'flex', justifyContent: 'center', alignItems: 'center',  minHeight: '100vh'}}>
//     <div style={{ display: 'flex', justifyContent: 'center', alignItems: 'center', boxShadow: '0 0 10px rgba(0, 0, 0, 0.1)', padding: '20px', width: '50%' }}>
//       <div className='Feedback_Form'>
//         <h1 style={{ textAlign: 'center' }}>Give Your Valuable Feedback :</h1>
//         <form onSubmit={sendEmail} ref={form}>
//           <div style={{ padding: '10px 0' }}>
//             <label>Name</label>
//             <input type="text" name="user_name" required onChange={() => setNameError('')} />
//             {nameError && <span style={{ color: 'red' }}>{nameError}</span>}
//           </div>
//           <div style={{ padding: '10px 0' }}>
//             <label>Email</label>
//             <input type="email" name="user_email" required onChange={() => setEmailError('')} />
//             {emailError && <span style={{ color: 'red' }}>{emailError}</span>}
//           </div>
//           <div style={{ padding: '10px 0' }}>
//             <label htmlFor='phone'>Phone:</label>
//             <input
//               type='tel'
//               id='phone'
//               name='phone'
//               required
//               pattern="[0-9]{10}"
//               title="Please enter a 10-digit phone number"
//               onChange={() => setPhoneError('')}
//             />
//             {phoneError && <span style={{ color: 'red' }}>{phoneError}</span>}
//           </div>
//           <div style={{ padding: '10px 0' }}>
//             <label>Message</label>
//             <textarea name="message" />
//           </div>
//           <input type="submit" value="Send" disabled={!isFormValid} />
//         </form>
//       </div>
//     </div>
//     </div>
//   )
// }

// export default Contact;

// import React, { useRef, useState } from 'react';
// import emailjs from '@emailjs/browser';

// const Contact = () => {
//   const form = useRef();
//   const [nameError, setNameError] = useState('');
//   const [emailError, setEmailError] = useState('');
//   const [phoneError, setPhoneError] = useState('');

//   const sendEmail = (e) => {
//     e.preventDefault();

//     // Validate form data
//     if (!validateName(form.current.user_name.value)) {
//       setNameError('Name should only contain alphabets and spaces');
//       return;
//     } else {
//       setNameError('');
//     }

//     if (!validateEmail(form.current.user_email.value)) {
//       setEmailError('Invalid email format');
//       return;
//     } else {
//       setEmailError('');
//     }

//     if (!validatePhone(form.current.phone.value)) {
//       setPhoneError('Phone number must be 10 digits');
//       return;
//     } else {
//       setPhoneError('');
//     }

//     // Send email using emailjs
//     emailjs.sendForm('service_jqsyh7n', 'template_03a5j4a', form.current, 'jdH7Utyafx9fZxebW')
//       .then((result) => {
//         console.log(result.text);
//         alert("Message sent successfully!");
//         form.current.reset();
//       }, (error) => {
//         console.log(error.text);
//         alert("Error sending message. Please try again later.");
//       });
//   };

//   const validateName = (name) => /^[a-zA-Z\s]+$/.test(name);
//   const validateEmail = (email) => /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email);
//   const validatePhone = (phone) => /^\d{10}$/.test(phone);

//   const isFormValid =
//     !nameError && !emailError && !phoneError && form.current && form.current.user_name.value && form.current.user_email.value && form.current.phone.value;

//   return (
//     <div style={{ display: 'flex', justifyContent: 'center', alignItems: 'center', minHeight: '100vh' }}>
//       <div style={{ boxShadow: '0 0 10px rgba(0, 0, 0, 0.1)', padding: '20px', width: '50%' }}>
//         <h1 style={{ textAlign: 'center' }}>Give Your Valuable Feedback :</h1>
//         <form onSubmit={sendEmail} ref={form}>
//           <div style={{ padding: '10px 0' }}>
//             <label>Name</label>
//             <input type="text" name="user_name" required onChange={() => setNameError('')} />
//             {nameError && <span style={{ color: 'red' }}>{nameError}</span>}
//           </div>
//           <div style={{ padding: '10px 0' }}>
//             <label>Email</label>
//             <input type="email" name="user_email" required onChange={() => setEmailError('')} />
//             {emailError && <span style={{ color: 'red' }}>{emailError}</span>}
//           </div>
//           <div style={{ padding: '10px 0' }}>
//             <label htmlFor='phone'>Phone:</label>
//             <input
//               type='tel'
//               id='phone'
//               name='phone'
//               required
//               pattern="[0-9]{10}"
//               title="Please enter a 10-digit phone number"
//               onChange={() => setPhoneError('')}
//             />
//             {phoneError && <span style={{ color: 'red' }}>{phoneError}</span>}
//           </div>
//           <div style={{ padding: '10px 0' }}>
//             <label>Message</label>
//             <textarea name="message" />
//           </div>
//           <input type="submit" value="Send" />
//         </form>
//       </div>
//     </div>
//   )
// }

// export default Contact;


import React, { useRef, useState } from 'react';
import { TextField, Button, Container, Grid, Typography, Box } from '@mui/material';
import emailjs from '@emailjs/browser';

const Contact = () => {
  const form = useRef();
  const [nameError, setNameError] = useState('');
  const [emailError, setEmailError] = useState('');
  const [phoneError, setPhoneError] = useState('');

  const sendEmail = (e) => {
    e.preventDefault();

    // Validate form data
    if (!validateName(form.current.user_name.value)) {
      setNameError('Name should only contain alphabets and spaces');
      return;
    } else {
      setNameError('');
    }

    if (!validateEmail(form.current.user_email.value)) {
      setEmailError('Invalid email format');
      return;
    } else {
      setEmailError('');
    }

    if (!validatePhone(form.current.phone.value)) {
      setPhoneError('Phone number must be 10 digits');
      return;
    } else {
      setPhoneError('');
    }

    // Send email using emailjs
    emailjs.sendForm('service_jqsyh7n', 'template_03a5j4a', form.current, 'jdH7Utyafx9fZxebW')
      .then((result) => {
        console.log(result.text);
        alert("Message sent successfully!");
        form.current.reset();
      }, (error) => {
        console.log(error.text);
        alert("Error sending message. Please try again later.");
      });
  };

  const validateName = (name) => /^[a-zA-Z\s]+$/.test(name);
  const validateEmail = (email) => /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email);
  const validatePhone = (phone) => /^\d{10}$/.test(phone);

  const isFormValid =
    !nameError && !emailError && !phoneError && form.current && form.current.user_name.value && form.current.user_email.value && form.current.phone.value;

  return (
    <Box display="flex" justifyContent="center" alignItems="center" minHeight="100vh">
      <Container component="div" maxWidth="sm" boxShadow={1} p={3}>
        <Typography variant="h4" align="center" gutterBottom>
          Give Your Valuable Feedback:
        </Typography>
        <form onSubmit={sendEmail} ref={form}>
          <Box py={2}>
            <TextField
              label="Name"
              name="user_name"
              variant="outlined"
              fullWidth
              required
              error={!!nameError}
              helperText={nameError}
              onChange={() => setNameError('')}
            />
          </Box>
          <Box py={2}>
            <TextField
              label="Email"
              name="user_email"
              type="email"
              variant="outlined"
              fullWidth
              required
              error={!!emailError}
              helperText={emailError}
              onChange={() => setEmailError('')}
            />
          </Box>
          <Box py={2}>
            <TextField
              label="Phone"
              name="phone"
              type="tel"
              variant="outlined"
              fullWidth
              required
              pattern="[0-9]{10}"
              title="Please enter a 10-digit phone number"
              error={!!phoneError}
              helperText={phoneError}
              onChange={() => setPhoneError('')}
            />
          </Box>
          <Box py={2}>
            <TextField
              label="Message"
              name="message"
              variant="outlined"
              fullWidth
              multiline
              rows={4}
            />
          </Box>
          <Box py={2}>
            <Button type="submit" variant="contained" color="primary" fullWidth disabled={!isFormValid}>
              Send
            </Button>
          </Box>
        </form>
      </Container>
    </Box>
  );
};

export default Contact;


