import React, { useState } from 'react';

const DeleteSession: React.FC<{ id: number }> = ({ id }) => {
    const [error, setError] = useState<string>('');
    const [success, setSuccess] = useState<string>('');

    const handleDelete = async () => {
        try {
            const response = await fetch(`/api/Session/${id}`, {
                method: 'DELETE',
            });

            if (!response.ok) {
                throw new Error('Failed to delete session');
            }

            setSuccess('Session deleted successfully');
            setError('');
        } catch (err) {
            setError('Failed to delete session' + err);
        }
    };

    return (
        <div className="p-6 max-w-md mx-auto bg-white rounded-lg shadow-md">
            <button
                onClick={handleDelete}
                className="w-full bg-red-500 text-white py-2 px-4 rounded-md hover:bg-red-600"
            >
                Delete Session
            </button>
            {error && <div className="mt-4 text-red-500">{error}</div>}
            {success && <div className="mt-4 text-green-500">{success}</div>}
        </div>
    );
};

export default DeleteSession;
