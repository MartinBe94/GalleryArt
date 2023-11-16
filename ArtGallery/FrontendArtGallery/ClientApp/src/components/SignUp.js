import React, { useState } from 'react';
import {
  MDBBtn,
  MDBContainer,
  MDBCard,
  MDBCardBody,
  MDBInput,
  MDBCheckbox
}
from 'mdb-react-ui-kit';
import { registerUser } from './apiService';

export const SignUp =() =>{

  const [userData, setUserData] = useState({
    name: '',
    email: '',
    password: '',
    repeatPassword: '',
    agreeTerms: false,
  });

  const handleInputChange = (e) => {
    const { name, value, type, checked } = e.target;
    
    // Handle checkbox separately
    if (type === 'checkbox') {
      setUserData({ ...userData, [name]: checked });
    } else {
      setUserData({ ...userData, [name]: value });
    }
  };

  const handleRegister = async () => {
    try {
      // Add form validation logic if needed

      // Call the registerUser function from your service
      await registerUser({
        Username: userData.name,
        Email: userData.email,
        Password: userData.password,
      });

      // Handle successful registration, e.g., redirect or show a success message
    } catch (error) {
      // Handle registration failure, e.g., show an error message
      console.error('Error registering user:', error);
    }
  };


  return (
    <MDBContainer fluid className='d-flex align-items-center justify-content-center bg-image' style={{backgroundImage: 'url(https://mdbcdn.b-cdn.net/img/Photos/new-templates/search-box/img4.webp)'}}>
    <div className='mask gradient-custom-3'></div>
    <MDBCard className='m-5' style={{maxWidth: '600px'}}>
      <MDBCardBody className='px-5'>
        <h2 className="text-uppercase text-center mb-5">Create an account</h2>
        <MDBInput wrapperClass='mb-4' label='Your Name' size='lg' id='form1' type='text' name='name' onChange={handleInputChange} />
        <MDBInput wrapperClass='mb-4' label='Your Email' size='lg' id='form2' type='email' name='email' onChange={handleInputChange} />
        <MDBInput wrapperClass='mb-4' label='Password' size='lg' id='form3' type='password' name='password' onChange={handleInputChange} />
        <MDBInput wrapperClass='mb-4' label='Repeat your password' size='lg' id='form4' type='password' name='repeatPassword' onChange={handleInputChange} />
        <div className='d-flex flex-row justify-content-center mb-4'>
          <MDBCheckbox name='agreeTerms' id='flexCheckDefault' label='I agree all statements in Terms of service' onChange={handleInputChange} />
        </div>
        <MDBBtn className='mb-4 w-100 gradient-custom-4' size='lg' onClick={handleRegister}>Register</MDBBtn>
      </MDBCardBody>
    </MDBCard>
  </MDBContainer>
  );
}
