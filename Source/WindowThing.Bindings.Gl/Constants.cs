using GLbitfield = System.UInt32;
using GLenum = System.UInt32;

namespace WindowThing.Bindings.Gl;

public static class Constants
{
	public const GLbitfield _glDepthBufferBit = 0x100;
	public const GLbitfield _glStencilBufferBit = 0x400;
	public const GLbitfield _glColorBufferBit = 0x4000;

	public const GLenum _glZero = 0x0;
	public const GLenum _glOne = 0x1;
	
	public const GLenum _glPoints = 0x0;
	public const GLenum _glLines = 0x1;
	public const GLenum _glLineLoop = 0x2;
	public const GLenum _glLineStrip = 0x3;
	public const GLenum _glTriangles = 0x4;
	public const GLenum _glTriangleStrip = 0x5;
	public const GLenum _glTriangleFan = 0x6;

	public const GLenum _glSrcColor = 0x300;
	public const GLenum _glOneMinusSrcColor = 0x301;
	public const GLenum _glSrcAlpha = 0x302;
	public const GLenum _glOneMinusSrcAlpha = 0x303;
	public const GLenum _glDstAlpha = 0x304;
	public const GLenum _glOneMinusDstAlpha = 0x305;
	public const GLenum _glDstColor = 0x306;
	public const GLenum _glOneMinusDstColor = 0x307;
	public const GLenum _glSrcAlphaSaturate = 0x308;
	
	public const GLenum _glCullFace = 0xB44;
	
	public const GLenum _glDepthTest = 0xB71;
	
	public const GLenum _glStencilTest = 0xB90;
	
	public const GLenum _glDither = 0xBD0;
	
	public const GLenum _glBlend = 0xBE2;
	
	public const GLenum _glScissorTest = 0xC11;
	
	public const GLenum _glTexture2D = 0xDE1;

	public const GLenum _glByte = 0x1400;
	public const GLenum _glUnsignedByte = 0x1401;
	public const GLenum _glShort = 0x1402;
	public const GLenum _glUnsignedShort = 0x1403;
	public const GLenum _glInt = 0x1404;
	public const GLenum _glUnsignedInt = 0x1405;
	public const GLenum _glFloat = 0x1406;

	public const GLenum _glHalfFloat = 0x140B;
	public const GLenum _glFixed = 0x140C;

	public const GLenum _glDepthComponent = 0x1902;
	public const GLenum _glRed = 0x1903;

	public const GLenum _glAlpha = 0x1906;
	public const GLenum _glRgb = 0x1907;
	public const GLenum _glRgba = 0x1908;
	public const GLenum _glLuminance = 0x1909;
	public const GLenum _glLuminanceAlpha = 0x190A;

	public const GLenum _glVendor = 0x1F00;
	public const GLenum _glRenderer = 0x1F01;
	public const GLenum _glVersion = 0x1F02;
	public const GLenum _glExtensions = 0x1F03;
	
	public const GLenum _glNearest = 0x2600;
	public const GLenum _glLinear = 0x2601;

	public const GLenum _glNearestMipmapNearest = 0x2700;
	public const GLenum _glLinearMipmapNearest = 0x2701;
	public const GLenum _glNearestMipmapLinear = 0x2702;
	public const GLenum _glLinearMipmapLinear = 0x2703;

	public const GLenum _glTextureMagFilter = 0x2800;
	public const GLenum _glTextureMinFilter = 0x2801;
	public const GLenum _glTextureWrapS = 0x2802;
	public const GLenum _glTextureWrapT = 0x2803;

	public const GLenum _glRepeat = 0x2901;

	public const GLenum _glConstantColor = 0x8001;
	public const GLenum _glOneMinusConstantColor = 0x8002;
	public const GLenum _glConstantAlpha = 0x8003;
	public const GLenum _glOneMinusConstantAlpha = 0x8004;
	
	public const GLenum _glUnsignedShort4444 = 0x8033;
	public const GLenum _glUnsignedShort5551 = 0x8034;

	public const GLenum _glPolygonOffsetFill = 0x8037;
	
	public const GLenum _glTexture3D = 0x806F;
	
	public const GLenum _glTextureWrapR = 0x8072;
	
	public const GLenum _glSampleAlphaToCoverage = 0x809E;
	
	public const GLenum _glSampleCoverage = 0x80A0;
	
	public const GLenum _glClampToEdge = 0x812F;

	public const GLenum _glTextureMinLod = 0x813A;
	public const GLenum _glTextureMaxLod = 0x813B;
	public const GLenum _glTextureBaseLevel = 0x813C;
	public const GLenum _glTextureMaxLevel = 0x813D;

	public const GLenum _glRg = 0x8227;
	public const GLenum _glRgInteger = 0x8228;

	public const GLenum _glProgramBinaryRetrievableHint = 0x8257;
	public const GLenum _glProgramSeparable = 0x8258;

	public const GLenum _glComputeWorkGroupSize = 0x8267;

	public const GLenum _glUnsignedShort565 = 0x8363;

	public const GLenum _glUnsignedInt2101010Rev = 0x8368;

	public const GLenum _glMirroredRepeat = 0x8370;

	public const GLenum _glTexture0 = 0x84C0;

	public const GLenum _glDepthStencil = 0x84F9;
	public const GLenum _glUnsignedInt248 = 0x84FA;

	public const GLenum _glTextureCubeMap = 0x8513;

	public const GLenum _glTextureCompareFunc = 0x884D;
	public const GLenum _glTextureCompareMode = 0x884C;

	public const GLenum _glMaxTextureImageUnits = 0x8872;

	public const GLenum _glArrayBuffer = 0x8892;
	public const GLenum _glElementArrayBuffer = 0x8893;

	public const GLenum _glStreamDraw = 0x88E0;
	public const GLenum _glStreamRead = 0x88E1;
	public const GLenum _glStreamCopy = 0x88E2;

	public const GLenum _glStaticDraw = 0x88E4;
	public const GLenum _glStaticRead = 0x88E5;
	public const GLenum _glStaticCopy = 0x88E6;

	public const GLenum _glDynamicDraw = 0x88E8;
	public const GLenum _glDynamicRead = 0x88E9;
	public const GLenum _glDynamicCopy = 0x88EA;
	public const GLenum _glPixelPackBuffer = 0x88EB;
	public const GLenum _glPixelUnpackBuffer = 0x88EC;

	public const GLenum _glUniformBuffer = 0x8A11;

	public const GLenum _glActiveUniformBlockMaxNameLength = 0x8A35;
	public const GLenum _glActiveUniformBlocks = 0x8A36;

	public const GLenum _glFragmentShader = 0x8B30;
	public const GLenum _glVertexShader = 0x8B31;

	public const GLenum _glShaderType = 0x8B4F;

	public const GLenum _glDeleteStatus = 0x8B80;
	public const GLenum _glCompileStatus = 0x8B81;
	public const GLenum _glLinkStatus = 0x8B82;
	public const GLenum _glValidateStatus = 0x8B83;
	public const GLenum _glInfoLogLength = 0x8B84;
	public const GLenum _glAttachedShaders = 0x8B85;
	public const GLenum _glActiveUniforms = 0x8B86;
	public const GLenum _glActiveUniformMaxLength = 0x8B87;
	public const GLenum _glShaderSourceLength = 0x8B88;
	public const GLenum _glActiveAttributes = 0x8B89;
	public const GLenum _glActiveAttributeMaxLength = 0x8B8A;

	public const GLenum _glShadingLanguageVersion = 0x8B8C;

	public const GLenum _glTexture2DArray = 0x8C1A;

	public const GLenum _glUnsignedInt10F11F11FRev = 0x8C3B;

	public const GLenum _glUnsignedInt5999Rev = 0x8C3E;

	public const GLenum _glTransformFeedbackVaryingMaxLength = 0x8C76;
	public const GLenum _glTransformFeedbackBufferMode = 0x8C7F;
	public const GLenum _glTransformFeedbackVaryings = 0x8C83;

	public const GLenum _glRasterizerDiscard = 0x8C89;
	
	public const GLenum _glTransformFeedbackBuffer = 0x8C8E;

	public const GLenum _glPrimitiveRestartFixedIndex = 0x8D69;
	
	public const GLenum _glRedInteger = 0x8D94;

	public const GLenum _glRgbInteger = 0x8D98;
	public const GLenum _glRgbaInteger = 0x8D99;

	public const GLenum _glInt2101010Rev = 0x8D9F;

	public const GLenum _glFloat32UnsignedInt248Rev = 0x8DAD;

	public const GLenum _glTextureSwizzleR = 0x8E42;
	public const GLenum _glTextureSwizzleG = 0x8E43;
	public const GLenum _glTextureSwizzleB = 0x8E44;
	public const GLenum _glTextureSwizzleA = 0x8E45;

	public const GLenum _glSampleMask = 0x8E51;

	public const GLenum _glCopyReadBuffer = 0x8F36;
	public const GLenum _glCopyWriteBuffer = 0x8F37;

	public const GLenum _glDrawIndirectBuffer = 0x8F3F;

	public const GLenum _glShaderStorageBuffer = 0x90D2;

	public const GLenum _glDispatchIndirectBuffer = 0x90EE;

	public const GLenum _glTexture2DMultisample = 0x9100;

	public const GLenum _glComputeShader = 0x91B9;

	public const GLenum _glAtomicCounterBuffer = 0x92C0;

	public const GLenum _glActiveAtomicCounterBuffers = 0x92D9;

	public const GLenum _glDepthStencilTextureMode = 0x90EA;
}
