import NavBar from "./Navbar";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import HomePage from "../../features/HomePage";
import ContactsDashboard from "../../features/contacts/dashboard/ContactsDashboard";
import ContactDetails from "../../features/contacts/details/ContactDetails";
import { Container } from "@mui/material";


function App() {   
    return (
    <BrowserRouter>
        <NavBar/>
        <Container>
        <Routes>
            <Route path="/" element={<HomePage />} />
            <Route path="/contacts" element={<ContactsDashboard />} />
            <Route path="/contacts/:id" element={<ContactDetails />} />
        </Routes>
        </Container>      
      </BrowserRouter>
    );
  }
  
  export default App;