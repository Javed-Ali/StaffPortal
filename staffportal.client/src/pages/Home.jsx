import { Link } from 'react-router-dom';

const Home = () => {
    return (
        <div className="min-h-screen flex flex-col justify-center items-center bg-gray-100">
            <h1 className="text-4xl font-bold mb-8">Welcome to the Staff Portal</h1>
            <div className="space-x-4">
                <Link
                    to="/admin"
                    className="bg-blue-500 text-white px-4 py-2 rounded hover:bg-blue-600"
                >
                    Admin Page
                </Link>
                <Link
                    to="/staff"
                    className="bg-green-500 text-white px-4 py-2 rounded hover:bg-green-600"
                >
                    Staff Page
                </Link>
            </div>
        </div>
    );
};

export default Home;