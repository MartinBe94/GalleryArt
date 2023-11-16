export const registerUser = async (userData) => {
    try {
      const response = await fetch('https://localhost:7175/api/SignUp', {
    method: 'POST',
    headers: {
        'Content-Type': 'application/json',
    },
    body: JSON.stringify(userData),
});
  
      if (!response.ok) {
        throw new Error('Failed to register user');
      }
  
      return await response.json();
    } catch (error) {
      console.error('Error registering user:', error);
      throw error;
    }
  };
  