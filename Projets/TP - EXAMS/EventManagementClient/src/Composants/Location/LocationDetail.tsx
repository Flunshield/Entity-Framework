import React, { useEffect, useState } from "react";

interface LocationDto {
    id: number;
    name: string;
    address: string;
    city: string;
    country: string;
    capacity: number;
}

interface LocationDetailProps {
    locationId: number;
}

const LocationDetail: React.FC<LocationDetailProps> = ({ locationId }) => {
    const [location, setLocation] = useState<LocationDto | null>(null);

    useEffect(() => {
        fetch(`/api/Location/${locationId}`)
            .then(res => res.json())
            .then(data => setLocation(data))
            .catch(console.error);
    }, [locationId]);

    if (!location) return <p className="text-gray-600">Chargement de l'emplacement...</p>;

    return (
        <div className="bg-white p-6 rounded-xl shadow-md">
            <h2 className="text-2xl font-bold text-gray-800">{location.name}</h2>
            <p className="text-gray-600">{location.address}, {location.city}, {location.country}</p>
            <p className="text-sm text-gray-500">Capacité : {location.capacity}</p>
        </div>
    );
};

export default LocationDetail;
