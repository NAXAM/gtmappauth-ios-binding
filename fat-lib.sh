######################
# Options
######################

REVEAL_ARCHIVE_IN_FINDER=true

UNIVERSAL_LIBRARY_DIR="${BUILD_DIR}/iphoneuniversal"
OUTPUT_DIR="${PROJECT_DIR}/Output/iphoneuniversal/"

rm -rf "$OUTPUT_DIR"
mkdir -p "$OUTPUT_DIR"

######################
# Create directory for universal
######################

rm -rf "${UNIVERSAL_LIBRARY_DIR}"
mkdir -p "${UNIVERSAL_LIBRARY_DIR}"

######################
# Build Frameworks
######################

function build() {
    LIB_NAME="$1"

    xcodebuild -project Pods.xcodeproj -scheme $1 -sdk appletvsimulator -configuration ${CONFIGURATION} clean build CONFIGURATION_BUILD_DIR=${BUILD_DIR}/${CONFIGURATION}-iphonesimulator/${LIB_NAME} 2>&1
    xcodebuild -project Pods.xcodeproj -scheme $1 -sdk appletvos -configuration ${CONFIGURATION} clean build CONFIGURATION_BUILD_DIR=${BUILD_DIR}/${CONFIGURATION}-iphoneos/${LIB_NAME} 2>&1
    
    SIMULATOR_LIBRARY_PATH="${BUILD_DIR}/${CONFIGURATION}-iphonesimulator/${LIB_NAME}/lib${LIB_NAME}.a"
    DEVICE_LIBRARY_PATH="${BUILD_DIR}/${CONFIGURATION}-iphoneos/${LIB_NAME}/lib${LIB_NAME}.a"
    LIB_FOLDER="${UNIVERSAL_LIBRARY_DIR}/${LIB_NAME}"
    
    mkdir -p "${LIB_FOLDER}"
    mkdir -p "${OUTPUT_DIR}/${LIB_NAME}"
    mkdir -p "${OUTPUT_DIR}/${LIB_NAME}/include"
    
    ######################
    # Make an universal binary
    ######################
    
    lipo "${SIMULATOR_LIBRARY_PATH}" "${DEVICE_LIBRARY_PATH}" -create -output "${LIB_FOLDER}/lib${LIB_NAME}.a" | echo
    
    ######################
    # On Release, copy the result to release directory
    ######################
    
    cp -r "${LIB_FOLDER}/" "${OUTPUT_DIR}/${LIB_NAME}"
    cp -r "${BUILD_DIR}/${CONFIGURATION}-iphoneos/${LIB_NAME}/" "${OUTPUT_DIR}/${LIB_NAME}/include"
    
}

libs=(AppAuth GTMAppAuth GTMSessionFetcher)
for lib in "${libs[@]}"
do
build $lib
done

if [ ${REVEAL_ARCHIVE_IN_FINDER} = true ]; then
open "${OUTPUT_DIR}/"
fi