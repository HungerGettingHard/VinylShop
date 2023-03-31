import { Box, Typography } from "@mui/material"
import { useSelector } from 'react-redux'
import OrderDialogListItem from "./OrderDialogListItem"

function OrderDialogList() {
    const cart = useSelector(state => state.cart.cartItems)

    return(
        <Box sx={{
            display: 'flex',
            flexDirection: 'column',
            alignItems: 'center',
            width: '100%',
            pb: '2%'
        }}>
            {cart.map((item) => <OrderDialogListItem key={item.id} item={item}/>)}
        </Box>
    )
}

export default OrderDialogList 