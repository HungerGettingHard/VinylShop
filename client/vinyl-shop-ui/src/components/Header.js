import { Box, Typography } from "@mui/material";
import colors from "../themes/colors";

function Header() {
  return(
    <Box sx={{
      backgroundColor: colors.azure,
      height: '15%',
      alignItems: 'center',
      display: 'flex',
      boxShadow: 2
    }}>
      <Typography sx={{
        display: 'flex',
        padding: '50px',
        fontSize: 36,
        fontWeight: 'bold',
        color: colors.white
      }}>
        ПЛАСТИНКИ
      </Typography>
    </Box>
  );
}

export default Header