import React, { useState } from 'react';

const DeleteSpeaker: React.FC<{ id: number }> = ({ id }) => {
    const [error, setError] = useState<string>('');
    const [success, setSuccess] = useState<string>('');

    const handleDelete = async () => {
        try {
            const response = await fetch(`/api/Speaker/${id}`, {
                method: 'DELETE',
            });

            if (!response.ok) {
                throw new Error('Failed to delete speaker');
            }

            setSuccess('Speaker deleted successfully');
            setError('');
        } catch (err) {
            setError('Failed to delete speaker');
        }
    };

    return (
        <div>
            <button
                onClick={handleDelete}
                className="bg-red-500 text-white py-2 px-4 rounded-md hover:bg-red-600"
            >
                Delete Speaker
            </button>
            {error && <div className="mt-4 text-red-500">{error}</div>}
            {success && <div className="mt-4 text-green-500">{success}</div>}
        </div>
    );
};

export default DeleteSpeaker;
