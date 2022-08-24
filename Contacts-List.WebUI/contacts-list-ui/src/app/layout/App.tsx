import NavBar from "./Navbar";
import { BrowserRouter } from "react-router-dom";
import HomePage from "../../features/HomePage";

function App() {   
    return (
    <BrowserRouter>
        <HomePage/>
      </BrowserRouter>
    );
  }
  
  export default App;