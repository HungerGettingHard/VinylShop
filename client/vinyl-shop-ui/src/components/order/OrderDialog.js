import { Box, ButtonBase, Typography } from "@mui/material"
import colors from '../../themes/colors'
import CloseIcon from '@mui/icons-material/Close';
import { useDispatch, useSelector } from "react-redux";
import { close } from '../../features/order/orderDialogSlice'
import OrderDialogList from "./OrderDialogList";
import DestinationSelector from "../destination/DestinationSelector";
import { makeOrder } from '../../app/actions/order/makeOrder'

function OrderDialog() {
    const dispatch = useDispatch()
    const selectedDestination = useSelector(store => store.orderDialog.selectedDestination)

    const onClose = () => {
      dispatch(close())
    }

    const onMakeOrder = () => {
      dispatch(makeOrder(selectedDestination))
      dispatch(close())
    }

    return(
    <Box sx={{
      position: "fixed",
      height: 500,
      width: 900,
      backgroundColor: colors.darkBackground,
      borderRadius: 2,
      display: 'flex',
    }}>
      <ButtonBase onClick={onClose} sx={{
        position: 'absolute',
        height: 38,
        width: 38,
        right: 2,
        top: 2,
        zIndex: 1
      }}>
        <CloseIcon sx={{ color: colors.white }}/>
      </ButtonBase>
      
      <Box sx={{
        height: 500,
        width: 650,
        overflow: 'scroll'
      }}>
        <OrderDialogList/>
      </Box>

      <Box sx={{
        height: 460,
        width: 250,
        backgroundColor: colors.dark,
        borderRadius: 2,
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'space-between',
        pt: 5,
        flexDirection: 'column'
      }}>
        <DestinationSelector/>
        <ButtonBase sx={{
          height: 60, width: 150,
          backgroundColor: colors.red,
          borderRadius: 2,
          mb: 4
        }} onClick={onMakeOrder}>
          <Typography sx={{
            color: colors.white, 
            fontWeight: 'bold',
            fontSize: 18,
            textAlign: 'center'}}>
            Заказать
          </Typography>
        </ButtonBase>
      </Box>
    </Box>)
}

export default OrderDialog