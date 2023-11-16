// Example usage in a component
import React from 'react';
import { useAuth } from './AuthContext';

export const Dashboard = () => {
  const { user } = useAuth();
  return (
    <div>
      {user ? (
        <h2>Welcome, {user.username}!</h2>
      ) : (
        <p>Please log in to access the dashboard.</p>
      )}
    </div>
  );
};
