import { SafeAreaView, View, StyleSheet, Text } from "react-native";
import { Colors } from "react-native/Libraries/NewAppScreen";

export default function Home() {
    return(
        <SafeAreaView>
            <View style={Style.container}>
                <Text style={Style.title}> Home Page </Text>
            </View>
        </SafeAreaView>
    )
}

const Style = StyleSheet.create({
    container: {
        flex: 1,
        margin: 24,
        alignContent: "center",
        alignItems: "center",
        justifyContent: "center"
    },
    title: {
        color: "#000000"
    }
});