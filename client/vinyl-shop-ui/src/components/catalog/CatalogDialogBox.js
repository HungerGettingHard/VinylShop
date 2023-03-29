import { useSelector } from "react-redux"
import { Box } from "@mui/material"
import CatalogDialog from "./CatalogDialog"

function CatalogDialogBox() {
  const isOpen = useSelector(store => store.catalogDialog.isOpen)

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
    <CatalogDialog/>
  </Box> : null}</>)
}

export default CatalogDialogBox