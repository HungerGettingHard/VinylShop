import { Box } from '@mui/material';
import Header from './components/Header';
import CatalogPage from './pages/CatalogPage';
import colors from './themes/colors';

function App() {
  return (
    <Box sx={{
      backgroundColor: colors.darkBackground,
      minHeight: '100%',
    }}>
      <Header/>
      <CatalogPage/>
    </Box>
  );
}

export default App
