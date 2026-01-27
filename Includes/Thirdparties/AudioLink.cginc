// AudioLink
//
// Copyright 2024 llealloo, cnlohr, lox9973, pema99, float3
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software 
// and associated documentation files (the "Software"), to deal in the Software without restriction, 
// including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, 
// subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial 
// portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT 
// LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. 
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, 
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE 
// SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
// You may freely use this code in any CC 3.0+ licensed projects.

    #define ALPASS_DFT                      uint2(0,4)  //Size: 128, 2
    #define ALPASS_WAVEFORM                 uint2(0,6)  //Size: 128, 16
    #define ALPASS_AUDIOLINK                uint2(0,0)  //Size: 128, 4
    #define ALPASS_AUDIOBASS                uint2(0,0)  //Size: 128, 1
    #define ALPASS_AUDIOLOWMIDS             uint2(0,1)  //Size: 128, 1
    #define ALPASS_AUDIOHIGHMIDS            uint2(0,2)  //Size: 128, 1
    #define ALPASS_AUDIOTREBLE              uint2(0,3)  //Size: 128, 1
    #define ALPASS_AUDIOLINKHISTORY         uint2(1,0)  //Size: 127, 4
    #define ALPASS_GENERALVU                uint2(0,22) //Size: 12, 1
    #define ALPASS_GENERALVU_INSTANCE_TIME  uint2(2,22)
    #define ALPASS_GENERALVU_LOCAL_TIME     uint2(3,22)
    #define ALPASS_GENERALVU_NETWORK_TIME   uint2(4,22)
    #define ALPASS_GENERALVU_PLAYERINFO     uint2(6,22)
    #define ALPASS_THEME_COLOR0             uint2(0,23)
    #define ALPASS_THEME_COLOR1             uint2(1,23)
    #define ALPASS_THEME_COLOR2             uint2(2,23)
    #define ALPASS_THEME_COLOR3             uint2(3,23)
    #define ALPASS_GENERALVU_UNIX_DAYS      uint2(5,23)
    #define ALPASS_GENERALVU_UNIX_SECONDS   uint2(6,23)
    #define ALPASS_GENERALVU_SOURCE_POS     uint2(7,23)
    #define ALPASS_MEDIASTATE               uint2(5,22)

    #define ALPASS_CCINTERNAL               uint2(12,22) //Size: 12, 2
    #define ALPASS_CCCOLORS                 uint2(25,22) //Size: 12, 1 (Note Color #0 is always black, Colors start at 1)
    #define ALPASS_CCSTRIP                  uint2(0,24)  //Size: 128, 1
    #define ALPASS_CCLIGHTS                 uint2(0,25)  //Size: 128, 2
    #define ALPASS_AUTOCORRELATOR           uint2(0,27)  //Size: 128, 1
    #define ALPASS_FILTEREDAUDIOLINK        uint2(0,28)  //Size: 16, 4
    #define ALPASS_CHRONOTENSITY            uint2(16,28) //Size: 8, 4
    #define ALPASS_FILTEREDVU               uint2(24,28) //Size: 4, 4
    #define ALPASS_FILTEREDVU_INTENSITY     uint2(24,28) //Size: 4, 1
    #define ALPASS_FILTEREDVU_MARKER        uint2(24,29) //Size: 4, 1
    #define ALPASS_GLOBAL_STRINGS           uint2(40,28) //Size: 8, 4

    // Some basic constants to use (Note, these should be compatible with
    // future version of AudioLink, but may change.
    #define AUDIOLINK_SAMPHIST              3069        // Internal use for algos, do not change.
    #define AUDIOLINK_SAMPLEDATA24          2046
    #define AUDIOLINK_EXPBINS               24
    #define AUDIOLINK_EXPOCT                10
    #define AUDIOLINK_ETOTALBINS            (AUDIOLINK_EXPBINS * AUDIOLINK_EXPOCT)
    #define AUDIOLINK_WIDTH                 128
    #define AUDIOLINK_SPS                   48000       // Samples per second
    #define AUDIOLINK_ROOTNOTE              0
    #define AUDIOLINK_4BAND_FREQFLOOR       0.123
    #define AUDIOLINK_4BAND_FREQCEILING     1
    #define AUDIOLINK_BOTTOM_FREQUENCY      13.75
    #define AUDIOLINK_BASE_AMPLITUDE        2.5
    #define AUDIOLINK_DELAY_COEFFICIENT_MIN 0.3
    #define AUDIOLINK_DELAY_COEFFICIENT_MAX 0.9
    #define AUDIOLINK_DFT_Q                 4.0
    #define AUDIOLINK_TREBLE_CORRECTION     5.0
    #define AUDIOLINK_4BAND_TARGET_RATE     90.0
    #define AUDIOLINK_LUT                   {0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, \
                                            0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, \
                                            0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, \
                                            0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.001, 0.002, 0.003, 0.004, 0.005, 0.006, \
                                            0.008, 0.01, 0.012, 0.014, 0.017, 0.02, 0.022, 0.025, 0.029, 0.032, 0.036, \
                                            0.04, 0.044, 0.048, 0.053, 0.057, 0.062, 0.067, 0.072, 0.078, 0.083, 0.089, \
                                            0.095, 0.101, 0.107, 0.114, 0.121, 0.128, 0.135, 0.142, 0.149, 0.157, 0.164, \
                                            0.172, 0.18, 0.188, 0.196, 0.205, 0.213, 0.222, 0.23, 0.239, 0.248, 0.257, \
                                            0.266, 0.276, 0.285, 0.294, 0.304, 0.313, 0.323, 0.333, 0.342, 0.352, 0.362, \
                                            0.372, 0.381, 0.391, 0.401, 0.411, 0.421, 0.431,  0.441, 0.451, 0.46, 0.47, \
                                            0.48, 0.49, 0.499, 0.509, 0.519, 0.528, 0.538, 0.547, 0.556, 0.565, 0.575, \
                                            0.584, 0.593, 0.601, 0.61, 0.619, 0.627, 0.636, 0.644, 0.652, 0.66, 0.668, \
                                            0.676, 0.684, 0.691, 0.699, 0.706, 0.713, 0.72, 0.727, 0.734, 0.741, 0.747, \
                                            0.754, 0.76, 0.766,  0.772, 0.778, 0.784, 0.79, 0.795, 0.801, 0.806, 0.811, \
                                            0.816, 0.821, 0.826, 0.831, 0.835, 0.84, 0.844, 0.848, 0.853, 0.857, 0.861, \
                                            0.864,  0.868, 0.872, 0.875, 0.879, 0.882, 0.885, 0.888, 0.891, 0.894, 0.897, \
                                            0.899, 0.902, 0.904, 0.906, 0.909, 0.911, 0.913, 0.914, 0.916, 0.918, 0.919, \
                                            0.921, 0.922, 0.924, 0.925, 0.926, 0.927, 0.928, 0.928, 0.929, 0.929, 0.93, \
                                            0.93, 0.93, 0.931, 0.931, 0.93, 0.93, 0.93, 0.93, 0.929, 0.929, 0.928, 0.927, \
                                            0.926, 0.925, 0.924, 0.923, 0.922, 0.92, 0.919, 0.917, 0.915, 0.913, 0.911, \
                                            0.909, 0.907, 0.905, 0.903, 0.9}

    #ifdef AUDIOLINK_STANDARD_INDEXING
        sampler2D _AudioTexture;
        #define AudioLinkData(xycoord) tex2Dlod(_AudioTexture, float4(uint2(xycoord) * _AudioTexture_TexelSize.xy, 0, 0))
    #else
        uniform Texture2D<float4>   _AudioTexture;
        #define AudioLinkData(xycoord) _AudioTexture[uint2(xycoord)]
    #endif

    // Convenient mechanism to read from the AudioLink texture that handles reading off the end of one line and onto the next above it.
    float4 AudioLinkDataMultiline(uint2 xycoord) { return AudioLinkData(uint2(xycoord.x % AUDIOLINK_WIDTH, xycoord.y + xycoord.x/AUDIOLINK_WIDTH)); }

    // Mechanism to sample between two adjacent pixels and lerp between them, like "linear" supesampling
    float4 AudioLinkLerp(float2 xy) { return lerp( AudioLinkData(xy), AudioLinkData(xy+int2(1,0)), frac( xy.x ) ); }

    // Same as AudioLinkLerp but properly handles multiline reading.
    float4 AudioLinkLerpMultiline(float2 xy) { return lerp(AudioLinkDataMultiline(xy), AudioLinkDataMultiline(xy+float2(1,0)), frac(xy.x)); }

        // Extra utility functions for time.
    uint AudioLinkDecodeDataAsUInt(uint2 indexloc)
    {
        uint4 rpx = AudioLinkData(indexloc);
        return rpx.x + rpx.y*1024 + rpx.z * 1048576 + rpx.w * 1073741824;
    }
