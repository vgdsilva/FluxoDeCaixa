import React from "react";
import { SafeAreaView, View } from "react-native";

export class BaseScreen extends React.Component<any, any> {
    render(): React.ReactNode {
        
        const { children } = this.props;

        return (
            <>
                <SafeAreaView>
                    <View>
                        {children}
                    </View>
                </SafeAreaView>
            </>
        );
    }
}