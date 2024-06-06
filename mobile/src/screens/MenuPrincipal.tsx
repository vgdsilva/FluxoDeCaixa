import { useLayoutEffect } from "react";
import { View, Text } from "react-native";


export default function MenuPrincipalScreen() {

    useLayoutEffect(() => {
        
    });

    return (
        <View style={{ display: "flex", justifyContent: "center", alignItems: "center"}}>
            <Text style={{ fontSize: 20 }}> Tela Menu Principal </Text>
        </View>
    );
}