import { Box } from "@mui/material";
import GenreSelector from "../components/genre/GenreSelector";

function Catalog() {
  return(
    <Box sx={{
      display: 'flex',
      height: '85%',
      margin: 0,
      flexGrow: 1,
      alignItems: 'center'
    }}>
      <GenreSelector/>
    </Box>
  );
}

export default Catalog