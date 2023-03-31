import { Box } from '@mui/material';
import Header from './components/Header';
import CatalogPage from './pages/CatalogPage';
import ProfilePage from './pages/ProfilePage';
import CartPage from './pages/CartPage';
import colors from './themes/colors';
import CatalogDialogBox from './components/catalog/CatalogDialogBox';
import SideMenu from './components/SideMenu';
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import OrderBox from './components/order/OrderBox';

function App() {
  return (
    <Router>
      <Box sx={{
        backgroundColor: colors.darkBackground,
        minHeight: '100%',
        display: 'flex',
      }}>
        <CatalogDialogBox/>
        <OrderBox/>
        <Header/>
        <Routes>
          <Route path="/" element={<CatalogPage/>}/>
          <Route path="/profile" element={<ProfilePage/>}/>
          <Route path="/cart" element={<CartPage/>}/>
        </Routes>
        <SideMenu/>
      </Box>
    </Router>
  );
}

export default App
