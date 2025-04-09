import React, { useState, useEffect } from 'react';

const UpdateSpeaker: React.FC<{ id: number }> = ({ id }) => {
    const [name, setName] = useState<string>('');
    const [title, setTitle] = useState<string>('');
    const [bio, setBio] = useState<string>('');
    const [error, setError] = useState<string>('');
    const [success, setSuccess] = useState<string>('');
    const [loading, setLoading] = useState<boolean>(true);

    useEffect(() => {
        const fetchSpeaker = async () => {
            try {
                const response = await fetch(`/api/Speaker/${id}`);
                if (!response.ok) {
                    throw new Error('Failed to fetch speaker');
                }
                const data = await response.json();
                setName(data.name);
                setTitle(data.title);
                setBio(data.bio);
            } catch (err) {
                setError('Unable to fetch speaker details');
            } finally {
                setLoading(false);
            }
        };

        fetchSpeaker();
    }, [id]);

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();

        const updatedSpeaker = { name, title, bio };

        try {
            const response = await fetch(`/api/Speaker/${id}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(updatedSpeaker),
            });

            if (!response.ok) {
                throw new Error('Failed to update speaker');
            }

            setSuccess('Speaker updated successfully');
            setError('');
        } catch (err) {
            setError('Failed to update speaker');
        }
    };

    if (loading) {
        return <div>Loading speaker details...</div>;
    }

    return (
        <div className="p-6 max-w-md mx-auto bg-white rounded-lg shadow-md">
            <h2 className="text-2xl font-semibold mb-4">Update Speaker</h2>
            <form onSubmit={handleSubmit}>
                <div className="mb-4">
                    <label htmlFor="name" className="block text-sm font-medium text-gray-700">Name</label>
                    <input
                        type="text"
                        id="name"
                        value={name}
                        onChange={(e) => setName(e.target.value)}
                        required
                        className="mt-1 block w-full p-2 border border-gray-300 rounded-md"
                    />
                </div>

                <div className="mb-4">
                    <label htmlFor="title" className="block text-sm font-medium text-gray-700">Title</label>
                    <input
                        type="text"
                        id="title"
                        value={title}
                        onChange={(e) => setTitle(e.target.value)}
                        required
                        className="mt-1 block w-full p-2 border border-gray-300 rounded-md"
                    />
                </div>

                <div className="mb-4">
                    <label htmlFor="bio" className="block text-sm font-medium text-gray-700">Bio</label>
                    <textarea
                        id="bio"
                        value={bio}
                        onChange={(e) => setBio(e.target.value)}
                        required
                        className="mt-1 block w-full p-2 border border-gray-300 rounded-md"
                    />
                </div>

                <button
                    type="submit"
                    className="w-full bg-blue-500 text-white py-2 px-4 rounded-md hover:bg-blue-600"
                >
                    Update Speaker
                </button>
            </form>

            {error && <div className="mt-4 text-red-500">{error}</div>}
            {success && <div className="mt-4 text-green-500">{success}</div>}
        </div>
    );
};

export default UpdateSpeaker;
