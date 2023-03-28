import { Box } from '@mui/material';
import Header from './components/Header';
import Catalog from './pages/Catalog';
import colors from './themes/colors';

function App() {
  return (
    <Box sx={{
      backgroundColor: colors.lightGray,
      height: '100%',
      flexDirection: 'column'
    }}>
      <Header/>
      <Catalog/>
    </Box>
  );
}

export default App
