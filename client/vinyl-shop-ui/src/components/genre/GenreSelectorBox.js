import { Accordion, Box, Typography, AccordionSummary, AccordionDetails } from "@mui/material"
import ExpandMoreIcon from '@mui/icons-material/ExpandMore';
import colors from "../../themes/colors";
import GenreSelector from '../genre/GenreSelector'

function GenreSelectorBox(){
  return(
    <Box sx={{ m: 2, width: '80%', backgroundColor: colors.dark, borderRadius: 2}}>
      <Accordion sx={{
        backgroundColor: 'rgba(0,0,0,0)',
      }}>
        <AccordionSummary 
          expandIcon={<ExpandMoreIcon sx={{color: colors.white}}/>}
          sx={{borderRadius: 2}}>
            <Typography sx={{ 
                width: '66%', 
                m: 1, 
                color: colors.white
            }}>
              Каталог
            </Typography>  
            <Typography sx={{ 
                width: '33%', 
                m: 1, 
                textAlign: 'right', 
                color: colors.white
            }}>
              Жанры
            </Typography>                   
        </AccordionSummary>
        <AccordionDetails sx={{
            backgroundColor: colors.dark,
            borderRadius: 2
        }}>
          <GenreSelector/>
        </AccordionDetails>
      </Accordion>
    </Box>
  )
}

export default GenreSelectorBox