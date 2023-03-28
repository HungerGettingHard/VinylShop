import { Box } from '@mui/material'
import CatalogList from './CatalogList';

function CatalogBox() {
  return(
    <Box sx={{
      display: 'flex',
      width: '80%',
      flexDirection: 'column'
    }}>
        <CatalogList/>
    </Box>
  );
}

export default CatalogBox