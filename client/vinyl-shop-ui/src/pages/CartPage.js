import { Box, ButtonBase, Typography } from "@mui/material";
import { useEffect } from "react";
import { useDispatch } from "react-redux";
import CartBox from "../components/cart/CartBox"
import { open } from "../features/order/orderDialogSlice";
import { setCart } from '../features/sideMenuSlice'
import colors from "../themes/colors";
import { getDestinations } from "../app/actions/order/orderDestinations";

function CartPage() {
  const dispatch = useDispatch()

  const handleOrderOpening = () => {
    dispatch(getDestinations())
    dispatch(open())
  }

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
      <ButtonBase sx={{
        backgroundColor: colors.purple,
        width: 200,
        height: 60,
        bottom: 0,
        borderRadius: 2
      }} onClick={handleOrderOpening}>
        <Typography sx={{
          fontSize: 20,
          color: colors.white
        }}>
          Оформить заказ
        </Typography>
      </ButtonBase>
    </Box>
  );
}

export default CartPage