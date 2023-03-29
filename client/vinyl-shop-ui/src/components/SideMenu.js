import { Box, ButtonBase } from "@mui/material"
import ShoppingCartIcon from '@mui/icons-material/ShoppingCart';
import PersonIcon from '@mui/icons-material/Person';
import AlbumIcon from '@mui/icons-material/Album';
import colors from "../themes/colors";
import { useSelector } from "react-redux";
import { useEffect } from "react";
import { Link } from "react-router-dom";

function SideMenu() {
  const sideMenu = useSelector(state => state.menu) 

  return(
    <Box sx={{
        height: '100%',
        position: 'fixed',
        width: 88,
        ml: -1,
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center',
    }}>
    <Box sx={{
        width: 88,
        height: 300,   
        pl: 1,     
        justifyContent: 'space-evenly',
        backgroundColor: colors.dark,
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center',
        borderRadius: 2,
      }}>
        <Link to="/">
          <ButtonBase sx={{
            height: 60,
            width: 60,
            display: 'flex',
            alignItems: 'center',
            justifyContent: 'center',
            borderRadius: 2,
          }}>
            <AlbumIcon sx={{ 
              color: sideMenu.isCatalogOpen === true ? colors.white : colors.gray,
              height: 40, 
              width: 40 }}/>
          </ButtonBase>
        </Link>

        <Link to="/cart">
          <ButtonBase sx={{
            height: 60,
            width: 60,
            display: 'flex',
            alignItems: 'center',
            justifyContent: 'center',
            borderRadius: 2,  
          }}>
            <ShoppingCartIcon sx={{
              color: sideMenu.isCartOpen === true ? colors.white : colors.gray, 
              height: 40, 
              width: 40 }}/>
          </ButtonBase>
        </Link>

        <Link to="/profile">
          <ButtonBase sx={{
            height: 60,
            width: 60,
            display: 'flex',
            alignItems: 'center',
            justifyContent: 'center',
            borderRadius: 2,
          }}>
            <PersonIcon sx={{ 
              color: sideMenu.isProfileOpen === true ? colors.white : colors.gray, 
              height: 40, width: 
              40 }}/>
          </ButtonBase>
        </Link>
      </Box>
    </Box>
  )
}

export default SideMenu