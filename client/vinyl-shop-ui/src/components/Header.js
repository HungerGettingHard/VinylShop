import { Box, Typography } from "@mui/material";
import colors from "../themes/colors";
import image from '../assets/logo.png'

function Header() {
  return(
    <Box sx={{
      backgroundColor: colors.dark,
      height: 120,
      width: '100%',
      alignItems: 'center',
      justifyContent: 'center',
      display: 'flex',
      position: 'fixed',
      zIndex: 1
    }}>
      <Box component="img"
        sx={{
          height: 70
        }}
        alt="Изображение"
        src={image}
      />
      <Typography sx={{
        display: 'flex',
        ml: '30px',
        fontSize: 50,
        fontWeight: 'bold',
        color: colors.white
      }}>
        VINYL
      </Typography>
    </Box>
  );
}

export default Header