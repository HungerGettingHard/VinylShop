import { Box } from "@mui/material";
import { useEffect } from "react";
import { useDispatch } from "react-redux";
import CartBox from "../components/cart/CartBox";
import { setCart } from '../features/sideMenuSlice'

function CartPage() {
  const dispatch = useDispatch()

  useEffect(() => {
    dispatch(setCart())
  }, [])

  return(
    <Box sx={{
      display: 'flex',
      alignItems: 'center',
      pt: '120px',  
      flexDirection: 'column',
      width: '100%',
    }}>
      <CartBox/>
    </Box>
  );
}

export default CartPage