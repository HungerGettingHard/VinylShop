import { useSelector } from "react-redux"
import { Box } from "@mui/material"
import OrderDialog from './OrderDialog'

function OrderBox() {
  const isOpen = useSelector(store => store.orderDialog.isOpen)

  return(<>{isOpen === true ? <Box sx={{
    backgroundColor: 'rgba(0, 0, 0, 0.8)',
    position: 'fixed',
    minHeight: '100%',
    width: '100%',
    m: 0,
    zIndex: 2,
    alignItems: 'center',
    justifyContent: 'center',
    display: 'flex'
  }}>
    <OrderDialog/>
  </Box> : null}</>)
}

export default OrderBox