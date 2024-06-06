import { View } from "react-native";

type NavigationBarProps = {
    title?: string,
    subtitle?: string,
    titleView?: {},
    onBackPress?: () => void,
    toolBarItens?: { 
        image: any; 
        command: () => void
    }[]
}


const NavigationBar = (props?: NavigationBarProps) => {
    return (
        <View>
            
        </View>
    )
}

export default NavigationBar;