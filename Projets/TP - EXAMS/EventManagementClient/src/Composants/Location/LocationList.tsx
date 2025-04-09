import React, { useEffect, useState } from "react";

interface LocationDto {
    id: number;
    name: string;
    address: string;
    city: string;
    country: string;
    capacity: number;
}

const LocationList: React.FC = () => {
    const [locations, setLocations] = useState<LocationDto[]>([]);

    useEffect(() => {
        fetch("/api/Location")
            .then(res => res.json())
            .then(data => setLocations(data))
            .catch(console.error);
    }, []);

    return (
        <div className="bg-white p-6 rounded-xl shadow-md">
            <h2 className="text-2xl font-bold mb-4 text-gray-800">Liste des Emplacements</h2>
            <ul className="space-y-4">
                {locations.map(location => (
                    <li key={location.id} className="border p-4 rounded-lg">
                        <h3 className="text-xl font-semibold">{location.name}</h3>
                        <p className="text-gray-600">{location.address}, {location.city}, {location.country}</p>
                        <p className="text-sm text-gray-500">Capacité : {location.capacity}</p>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default LocationList;
