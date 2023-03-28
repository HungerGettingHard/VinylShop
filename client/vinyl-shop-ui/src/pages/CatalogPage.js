import { Box } from "@mui/material";
import CatalogBox from "../components/catalog/CatalogBox";
import GenreSelectorBox from "../components/genre/GenreSelectorBox";

function CatalogPage() {
  return(
    <Box sx={{
      display: 'flex',
      alignItems: 'center',
      pt: '120px',
      justifyContent: 'center',
      flexDirection: 'column'
    }}>
      <GenreSelectorBox/>
      <CatalogBox/>
    </Box>
  );
}

export default CatalogPage