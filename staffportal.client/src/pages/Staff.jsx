import axios from '../axiosConfig';
import { useState } from 'react';
import { useNavigate } from 'react-router-dom';

const Staff = () => {
    const [employeeNumber, setEmployeeNumber] = useState('');
    const [staff, setStaff] = useState(null);
    const [error, setError] = useState('');
    const [form, setForm] = useState({
        firstName: '',
        lastName: '',
        dateOfBirth: '',
        gender: '',
        qualification: ''
    });
    const navigate = useNavigate();

    const goToHome = () => {
        navigate('/');
    };

    const handleSearch = async () => {
        try {
            const response = await axios.get(`/api/Staff/${employeeNumber}`);
            setStaff(response.data);
            setForm({ 
                firstName: response.data.firstName,
                lastName: response.data.lastName,
                dateOfBirth: response.data.dateOfBirth.split('T')[0], // Format date for input type="date"
            });
            setError('');
        } catch (err) {
            setStaff(null);
            setError('Record not found');
        }
    };

    const handleChange = (e) => {
        setForm({
            ...form,
            [e.target.name]: e.target.value
        });
    };

    const handleUpdate = async () => {
        try {
            await axios.put(`/api/Staff/${employeeNumber}`, {
                employeeNumber,
                firstName: form.firstName,
                lastName: form.lastName,
                dateOfBirth: form.dateOfBirth,
                genderId: staff.gender.id,  // Use gender id fetched from backend
                qualificationId: staff.qualification.id  // Use qualification id fetched from backend
            });
            setError('');
            alert('Staff record updated successfully');
        } catch (err) {
            setError('Failed to update record');
        }
    };

    return (
        <div className="min-h-screen flex flex-col justify-center items-center bg-gray-100 p-4">
            <h1 className="text-4xl font-bold mb-8">Staff Page</h1>
            <div className="mb-4">
                <input
                    type="text"
                    value={employeeNumber}
                    onChange={(e) => setEmployeeNumber(e.target.value)}
                    placeholder="Enter Employee Number"
                    className="border px-4 py-2 mr-2"
                />
                <button
                    onClick={handleSearch}
                    className="bg-blue-500 text-white px-4 py-2 rounded hover:bg-blue-600"
                >
                    Search
                </button>
            </div>
            {error && <p className="text-red-500">{error}</p>}
            {staff && (
                <div className="bg-white p-4 shadow rounded w-full max-w-md">
                    <div className="mb-4">
                        <label className="block text-gray-700">First Name:</label>
                        <input
                            type="text"
                            name="firstName"
                            value={form.firstName}
                            onChange={handleChange}
                            className="border px-4 py-2 w-full"
                        />
                    </div>
                    <div className="mb-4">
                        <label className="block text-gray-700">Last Name:</label>
                        <input
                            type="text"
                            name="lastName"
                            value={form.lastName}
                            onChange={handleChange}
                            className="border px-4 py-2 w-full"
                        />
                    </div>
                    <div className="mb-4">
                        <label className="block text-gray-700">Date of Birth:</label>
                        <input
                            type="date"
                            name="dateOfBirth"
                            value={form.dateOfBirth}
                            onChange={handleChange}
                            className="border px-4 py-2 w-full"
                        />
                    </div>
                    <button
                        onClick={handleUpdate}
                        className="bg-green-500 text-white px-4 py-2 rounded hover:bg-green-600"
                    >
                        Update
                    </button>
                    <button
                        onClick={goToHome}
                        className="bg-blue-500 ml-6 text-white px-4 py-2 rounded hover:bg-green-600"
                    >
                        Home
                    </button>
                </div>
            )}
        </div>
    );
};

export default Staff;