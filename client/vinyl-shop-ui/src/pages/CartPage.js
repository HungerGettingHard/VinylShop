import { Box } from "@mui/material";
import { useEffect } from "react";
import { useDispatch } from "react-redux";
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
      justifyContent: 'center',
      flexDirection: 'column'
    }}>
    </Box>
  );
}

export default CartPage