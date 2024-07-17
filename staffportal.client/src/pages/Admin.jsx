import { useState, useEffect } from 'react';
import axios from '../axiosConfig';

const Admin = () => {
    const [employeeNumber, setEmployeeNumber] = useState('');
    const [staff, setStaff] = useState(null);
    const [message, setMessage] = useState('');
    const [form, setForm] = useState({
        employeeNumber: '',
        firstName: '',
        lastName: '',
        dateOfBirth: '',
        genderId: '',
        qualificationId: '',
        yearsOfWorkExperience: ''
    });
    const [genders, setGenders] = useState([]);
    const [qualifications, setQualifications] = useState([]);
    const [allStaff, setAllStaff] = useState([]);

    useEffect(() => {
        fetchGenders();
        fetchQualifications();
        fetchAllStaff();
    }, []);

    const fetchGenders = async () => {
        try {
            const response = await axios.get('/api/Gender');
            setGenders(response.data);
        } catch (error) {
            console.error('Error fetching genders:', error);
        }
    };

    const fetchQualifications = async () => {
        try {
            const response = await axios.get('/api/Qualification');
            setQualifications(response.data);
        } catch (error) {
            console.error('Error fetching qualifications:', error);
        }
    };

    const fetchAllStaff = async () => {
        try {
            const response = await axios.get('/api/Staff');
            const staffWithSalary = response.data.map(staff => ({
                ...staff,
                salary: calculateSalary(staff.qualification.level, staff.yearsOfWorkExperience)
            }));
            setAllStaff(staffWithSalary);
        } catch (error) {
            console.error('Error fetching all staff:', error);
        }
    };

    const calculateSalary = (qualificationLevel, yearsOfWorkExperience) => {
        const salary = (qualificationLevel / 10) * (yearsOfWorkExperience / 5) * 100000;
        return Math.round(salary); // Round salary to nearest integer
    };

    const handleChange = (e) => {
        setForm({
            ...form,
            [e.target.name]: e.target.value
        });
    };

    const handleCreate = async () => {
        try {
  
            await axios.post('/api/Staff', form);
            setMessage('Staff record created successfully');
            fetchAllStaff(); // Refresh the staff list after creation
            setForm({
                employeeNumber: '',
                firstName: '',
                lastName: '',
                dateOfBirth: '',
                genderId: '',
                qualificationId: '',
                yearsOfWorkExperience: ''
            });
        } catch (error) {
            setMessage('Failed to create staff record');
            console.error('Error creating staff:', error);
        }
    };

    const handleDelete = async () => {
        try {
            await axios.delete(`/api/Staff/${employeeNumber}`);
            setMessage('Staff record deleted successfully');
            setStaff(null); // Clear the staff state after deletion
            fetchAllStaff(); // Refresh the staff list after deletion
            
        } catch (error) {
            setMessage('Failed to delete staff record');
            console.error('Error deleting staff:', error);
        }
    };

    return (
        <div className="container mx-auto p-4">
            <div className="flex flex-wrap">
                {/* Column for Create and Delete Staff */}
                <div className="w-full md:w-1/2 p-4">
                    <h2 className="text-xl font-bold mb-4">Create Staff</h2>
                    <div>
                        <input
                            type="text"
                            name="employeeNumber"
                            placeholder="Employee Number"
                            value={form.employeeNumber}
                            onChange={handleChange}
                            className="border p-2 mb-2 w-full"
                        />
                        <input
                            type="text"
                            name="firstName"
                            placeholder="First Name"
                            value={form.firstName}
                            onChange={handleChange}
                            className="border p-2 mb-2 w-full"
                        />
                        <input
                            type="text"
                            name="lastName"
                            placeholder="Last Name"
                            value={form.lastName}
                            onChange={handleChange}
                            className="border p-2 mb-2 w-full"
                        />
                        <input
                            type="date"
                            name="dateOfBirth"
                            placeholder="Date of Birth"
                            value={form.dateOfBirth}
                            onChange={handleChange}
                            className="border p-2 mb-2 w-full"
                        />
                        <select
                            name="genderId"
                            value={form.genderId}
                            onChange={handleChange}
                            className="border p-2 mb-2 w-full"
                        >
                            <option value="">Select Gender</option>
                            {genders.map((gender) => (
                                <option key={gender.id} value={gender.id}>
                                    {gender.description}
                                </option>
                            ))}
                        </select>
                        <select
                            name="qualificationId"
                            value={form.qualificationId}
                            onChange={handleChange}
                            className="border p-2 mb-2 w-full"
                        >
                            <option value="">Select Qualification</option>
                            {qualifications.map((qualification) => (
                                <option key={qualification.id} value={qualification.id}>
                                    {qualification.description}
                                </option>
                            ))}
                        </select>
                        <input
                            type="number"
                            name="yearsOfWorkExperience"
                            placeholder="Years of Work Experience"
                            value={form.yearsOfWorkExperience}
                            onChange={handleChange}
                            className="border p-2 mb-2 w-full"
                        />
                        <button
                            onClick={handleCreate}
                            className="bg-green-500 text-white px-4 py-2 rounded hover:bg-green-600 w-full"
                        >
                            Create Staff
                        </button>
                    </div>
                    <h2 className="text-xl font-bold mt-8 mb-4">Delete Staff</h2>
                    <div>
                        <input
                            type="text"
                            placeholder="Employee Number"
                            value={employeeNumber}
                            onChange={(e) => setEmployeeNumber(e.target.value)}
                            className="border p-2 mb-2 w-full"
                        />
                        <button
                            onClick={handleDelete}
                            className="bg-red-500 text-white px-4 py-2 rounded hover:bg-red-600 w-full"
                        >
                            Delete Staff
                        </button>
                        {message && <p className="mt-2 text-green-500">{message}</p>}
                    </div>
                </div>
                {/* Column for Viewing All Staff */}
                <div className="w-full md:w-1/2 p-4">
                    <h2 className="text-xl font-bold mb-4">All Staff</h2>
                    <table className="min-w-full bg-white">
                        <thead>
                            <tr>
                                <th className="py-2">Employee Number</th>
                                <th className="py-2">First Name</th>
                                <th className="py-2">Last Name</th>
                                <th className="py-2">Date of Birth</th>
                                <th className="py-2">Gender</th>
                                <th className="py-2">Qualification</th>
                                <th className="py-2">Years of Experience</th>
                                <th className="py-2">Salary</th> {/* Add Salary column */}
                            </tr>
                        </thead>
                        <tbody>
                            {allStaff.map((staff) => (
                                <tr key={staff.employeeNumber}>
                                    <td className="border px-4 py-2">{staff.employeeNumber}</td>
                                    <td className="border px-4 py-2">{staff.firstName}</td>
                                    <td className="border px-4 py-2">{staff.lastName}</td>
                                    <td className="border px-4 py-2">{staff.dateOfBirth.split('T')[0]}</td>
                                    <td className="border px-4 py-2">{staff.gender.description}</td>
                                    <td className="border px-4 py-2">{staff.qualification.description}</td>
                                    <td className="border px-4 py-2">{staff.yearsOfWorkExperience}</td>
                                    <td className="border px-4 py-2">{staff.salary}</td> {/* Display Salary */}
                                </tr>
                            ))}
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    );
};

export default Admin;