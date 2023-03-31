import { Box, ButtonBase} from "@mui/material"
import colors from '../../themes/colors'
import CloseIcon from '@mui/icons-material/Close';
import { useDispatch } from "react-redux";
import { close } from '../../features/order/orderDialogSlice'
import OrderDialogList from "./OrderDialogList";

function OrderDialog() {
    const dispatch = useDispatch()

    const onClose = () => {
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
        height: 500,
        width: 250,
        backgroundColor: colors.dark,
        borderRadius: 2
      }}>

      </Box>
    </Box>)
}

export default OrderDialog