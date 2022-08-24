import NavBar from "./Navbar";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import HomePage from "../../features/HomePage";
import { Container } from "@mui/material";
import ContactDetails from "../../features/contacts/ContactDetails";
import ContactDashboard from "../../features/contacts/ContactsDashboard";

function App() {   
    return (
    <BrowserRouter>
        <NavBar/>
        <Container>
        <Routes>
            <Route path="/" element={<HomePage />} />
            <Route path="/contacts" element={<ContactDashboard />} />
            <Route path="/contacts/:id" element={<ContactDetails />} />
        </Routes>
        </Container>      
      </BrowserRouter>
    );
  }
  
  export default App;