 
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Home from './pages/Home';
import Admin from './pages/Admin';
import Staff from './pages/Staff';
function App() {
  

  return (
      <Router>
          <Routes>
              <Route path="/" element={<Home />} />
              <Route path="/admin" element={<Admin />} />
              <Route path="/staff" element={<Staff />} />
          </Routes>
      </Router>
  )
}

export default App
